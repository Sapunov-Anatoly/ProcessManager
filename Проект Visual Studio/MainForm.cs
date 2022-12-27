using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using System.ComponentModel;

namespace ProcessManager
{
    public partial class MainForm : Form
    {
        private class ConfigData
        {
            public int refreshRate { get; set; }
        }

        private Logger logFile;
        private int refreshRate;
        private static ManualResetEvent threadStatus = new ManualResetEvent( true );
        private Thread getProcessesThread;
        private IDictionary previousProcesses = new Dictionary<int, string>() { };

        public MainForm()
        {
            InitializeComponent();

            CreateLogFile();
            InstallingRefreshRate();

            StartThread();
        }

        private void CreateLogFile()
        {
            try
            {
                string pathToExe = Environment.CurrentDirectory.ToString();
                string pathToLogFile = pathToExe + "\\Logs";
                string logFileName = pathToLogFile + "\\Log_" + GetDate() + ".txt";

                logFile = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(logFileName).CreateLogger();
            }
            catch
            {
                MessageBox.Show("При создании журнала действий возникла непредвиденная ошибка, действия не будут записываться в отдельный файл.",
                                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InstallingRefreshRate()
        {
            try
            {
                ConfigData returnedConfig = GetConfig();
                refreshRate = returnedConfig.refreshRate * 1000;
                logFile.Information("Частота обновления списка процессов установлена на " + returnedConfig.refreshRate + " сек.");
            }
            catch
            {
                MessageBox.Show("Файл настроек был потерян, либо содержит недопустимые символы. В качестве частоты обновления списка процессов будет установлена стандартная частота - 5 сек.",
                                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshRate = 5000;

                logFile.Error("Файл настроек был потерян, либо содержит недопустимые символы.");
                logFile.Information("Частота обновления списка процессов установлена на " + refreshRate + " сек.");
            }
        }

        static ConfigData GetConfig()
        {
            string getPathToExe = Environment.CurrentDirectory.ToString();
            string pathToConfig = getPathToExe + "\\config.json";
            string configText = File.ReadAllText(pathToConfig);
            ConfigData returnedConfig = JsonConvert.DeserializeObject<ConfigData>(configText);

            return returnedConfig;
        }

        private void processDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int processId = Convert.ToInt32(processDataGridView.Rows[e.RowIndex].Cells[0].Value);

                GetProcessInfo(processId);
            }
            catch { } // Для того случая, если пользователь будет кликать на названия столбцов
        }

        private void StartThread()
        {
            try
            {
                getProcessesThread = new Thread(UpdateProcessesList);
                getProcessesThread.Start();

                logFile.Information("Запущен мониторинг активных процессов.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logFile.Warning("Программа завершена с ошибкой. " + ex.Message);
                Application.Exit();
            }
        }

        private void FindAddedAndDeletedProcesses(IDictionary actualProcesses)
        {
            try
            {
                if (previousProcesses.Count > 0)
                {
                    foreach (DictionaryEntry prevPoc in previousProcesses)
                    {
                        int procIdInCollection = Convert.ToInt32(prevPoc.Key);

                        if (!actualProcesses.Contains(procIdInCollection))
                        {
                            actualProcesses.Remove(procIdInCollection);
                            logFile.Debug("Удален процесс. ID: " + procIdInCollection + " Имя: " + prevPoc.Value);
                        }
                        else
                        {
                            actualProcesses.Remove(procIdInCollection);
                        }
                    }

                    foreach (DictionaryEntry prevPoc in actualProcesses)
                    {
                        logFile.Debug("Добавлен процесс. ID: " + Convert.ToInt32(prevPoc.Key) + " Имя: " + prevPoc.Value);
                    }
                }
            }
            catch(Exception ex)
            {
                logFile.Warning("Не удалось получить информацию по удаленным и добавленным процессам. " + ex.Message);
            }

            actualProcesses.Clear();
            previousProcesses.Clear();
        }

        private void UpdateProcessesList()
        {
            IDictionary actualProcesses = new Dictionary<int, string>() { };

            while (true)
            {
                threadStatus.WaitOne();

                Process[] processesList = Process.GetProcesses();

                foreach (Process process in processesList)
                {
                    actualProcesses.Add(process.Id, process.ProcessName);
                }

                FindAddedAndDeletedProcesses(actualProcesses);

                processDataGridView.Invoke((MethodInvoker)delegate
                {
                    processDataGridView.Rows.Clear();

                    foreach (Process process in processesList)
                    {
                        processDataGridView.Rows.Add(process.Id,
                                                     process.ProcessName,
                                                     Math.Round(process.PagedMemorySize64 / 1048576.0, 2));

                        previousProcesses.Add(process.Id, process.ProcessName);
                    }

                    this.processDataGridView.Sort(this.processDataGridView.Columns["processMemoryColumn"], ListSortDirection.Descending);
                });

                logFile.Information("Список активных процессов обновлен.");
                Thread.Sleep(refreshRate);
            } 
        }

        private void GetProcessInfo(int procId)
        {
            try
            {
                Process process = Process.GetProcessById(procId);

                MessageBox.Show("Имя процесса: " + process.ProcessName + "\n\n" +
                                "Начало работы процесса: " + process.StartTime + "\n\n" +
                                "Исполняемый файл: " + process.MainModule.ModuleName + "\n\n" +
                                "Путь к исполняемому файлу: " + process.MainModule.FileName + "\n\n",
                                "Свойства процесса", MessageBoxButtons.OK, MessageBoxIcon.Information);

                logFile.Information("Получена информация по процессу. ID: " + process.Id + " Имя: " + process.ProcessName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                logFile.Warning("Получение информации по процессу было завершено c ошибкой. " + ex.Message + ". ID процесса: " + procId);
            }
        }

        static string GetDate()
        {
            string dateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace(":", "_");
            return dateTime;
        }

        private void startProcessCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threadStatus.Set();

            startProcessCheckToolStripMenuItem.Enabled = false;
            stopProcessCheckToolStripMenuItem.Enabled = true;
            startProcessCheckToolStripMenuItem.BackColor = Color.LightGray;
            stopProcessCheckToolStripMenuItem.BackColor = Color.LightCoral;

            logFile.Information("Мониторинг активных процессов возобновлен.");
        }

        private void stopProcessCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threadStatus.Reset();

            stopProcessCheckToolStripMenuItem.Enabled = false;
            startProcessCheckToolStripMenuItem.Enabled = true;
            stopProcessCheckToolStripMenuItem.BackColor = Color.LightGray;
            startProcessCheckToolStripMenuItem.BackColor = Color.GreenYellow;

            logFile.Information("Мониторинг активных процессов приостановлен.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (getProcessesThread.IsAlive)
                {
                    getProcessesThread.Abort();
                }
            }
            catch(Exception ex)
            {
                logFile.Warning("Завершение потока мониторинга завершено с ошибкой. " + ex.Message);
            }

            logFile.Information("Программа завершила свою работу.");
        }    
    }
}
