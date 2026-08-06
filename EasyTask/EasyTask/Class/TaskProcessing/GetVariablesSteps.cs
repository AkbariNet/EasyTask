using EasyTask.Pages;
using System;
using System.Windows;

namespace EasyTask.Class.TaskProcessing
{
    class GetVariablesSteps
    {
        //Date Variables
        public int year;
        public int month;
        public int day;
        
        // Time Variables
        public int hour;
        public int minute;


        // Action Variables
        public string TypeOfAction;

        //TaskName Variable

        public string TaskName;

        DateTime DateCreatedTask=DateTime.Now;

        //----------------------------------------------------------------
        // checking Date For Enter True Date

        public bool checkYear(int yearRequest)
                    {
            
                        if (DateTime.Now.Year < yearRequest)
                        {
                            year = yearRequest;
                            return true;
                        }
                        else if (DateTime.Now.Year == yearRequest)
                        {
                            if (month < DateTime.Now.Month)
                            {
                                return false;
                            }
                            else
                            {
                                year = yearRequest;
                                return true;

                            }
                        }
                        else { return false; }
                    }
                    public bool checkMonth(int monthRequest)
                    {
                        if (monthRequest > 0 && monthRequest < 13)
                        {
                            if (year == DateTime.Now.Year)
                            {
                                if (monthRequest >= DateTime.Now.Month)
                                {
                                    month = monthRequest;
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if (year > DateTime.Now.Year)
                            {
                                month = monthRequest;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                    public bool checkDay(int dayRequest)
                    {
                        if (dayRequest > 0 && dayRequest <= 31)
                        {
                            if (year == DateTime.Now.Year && month == DateTime.Now.Month)
                            {
                                if (dayRequest >= DateTime.Now.Day)
                                {
                                    try
                                    {
                                        DateTime CheckOk = new DateTime(year, month, dayRequest);
                                        day = dayRequest;
                                        return true;

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        return false;
                                        throw;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                            }
                            else
                            {

                                try
                                {
                                    DateTime CheckOk = new DateTime(year, month, dayRequest);
                                    day = dayRequest;
                                    return true;

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return false;
                                    throw;
                                }
                            }

                        }
                        else
                        {
                            return false;
            }
        }

        // checking Date For Enter True Date
        //----------------------------------------------------------------



        //----------------------------------------------------------------
                    //Checking Time For Enter True Time
                    public bool checkHour(int hourRequest)
                    {
                        DateTime CheckDate = new DateTime(year , month, day);
                        if (hourRequest >= 0 && hourRequest < 25)
                        {
                            if (CheckDate.Date == DateTime.Now.Date)
                            {
                                if (hourRequest >= DateTime.Now.Hour)
                                {
                                    hour = hourRequest;
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if (CheckDate.Date < DateTime.Now.Date)
                            {

                    ProcessInProduct processInProduct = new ProcessInProduct();
                    processInProduct.StartProssesing();
                    processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.ProcessInProduct_Invalid_Value , EasyTask.Properties.Languages.Lang.ProcessInProduct_Error_On_Calulate_Of_Date__Please_Return_to_Step1 );
                    processInProduct.ShowDialog();
                    return false;
                            }
                            else if (CheckDate.Date >= DateTime.Now.Date)
                            {
                                hour = hourRequest;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else { return false; }
                    }
                    public bool checkMinute(int minuteRequest)
                    {
                        DateTime CheckDate = new DateTime(year, month, day);
                        if (minuteRequest >= 0 && minuteRequest < 60)
                        {
                            if (CheckDate.Date == DateTime.Now.Date)
                            {
                                if (hour == DateTime.Now.Hour)
                                {
                                    if (minuteRequest > DateTime.Now.Minute)
                                    {
                                        minute = minuteRequest;
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else if (hour > DateTime.Now.Hour)
                                {
                                    minute = minuteRequest;
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if (CheckDate.Date > DateTime.Now.Date)
                            {
                                minute = minuteRequest;
                                return true;
                            }
                            else 
                            {
                    
                                return false;
                            }
                        }
                        else { return false; }
                    }

                    //Checking Time For Enter True Time
        //----------------------------------------------------------------

        public DateTime FirstSet()
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            day = DateTime.Now.Day;
            hour = DateTime.Now.Hour;
            if (DateTime.Now.Minute != 59)
            {
                minute = DateTime.Now.Minute + 1;

            }
            else
            {

                hour = DateTime.Now.Hour + 1;
                minute = 0;
            }

            DateTime sendFirstValue = new DateTime(year, month, day, hour, minute, 00);
            try
            {
                DateTime dateCreatedTask = DateTime.Now;
                dateCreatedTask = DateCreatedTask;

            }
            catch (Exception)
            {
                DateTime dateCreatedTask = DateTime.Now.Date;

                dateCreatedTask = DateCreatedTask;
                throw;
            }
            return sendFirstValue;
        }
        public bool FinalSaveToDataBase(Window window,string pathFile)
        {
            DateTime RunDate = new DateTime(year, month, day,hour,minute,00);
           bool trueYear= checkYear(year);
           bool trueMonth= checkMonth(month);
           bool trueDay= checkDay(day);
           bool trueHour= checkHour(hour);
           bool trueMinute= checkMinute(minute);
            AddTaskProcess addTaskProcess = new AddTaskProcess();
            if (!trueYear || !trueMonth || !trueDay || !trueHour || !trueMinute)
            {
                window.Close();
                ProcessInProduct processInProduct = new ProcessInProduct();
                processInProduct.StartProssesing(EasyTask.Properties.Languages.Lang.ProcessInProduct_Adding__, EasyTask.Properties.Languages.Lang.ProcessInProduct_trying_to_add_to_database__);
                processInProduct.GetRespond(false, EasyTask.Properties.Languages.Lang.ProcessInProduct_Data_Invalid, EasyTask.Properties.Languages.Lang.ProcessInProduct_Action_time_is_behinded_of_system_Time_);
                processInProduct.ShowDialog();
                return false;
            }
            else
            {

                addTaskProcess.AddTaskToDataBase(TaskName, DateCreatedTask, RunDate, TypeOfAction, window,pathFile);
                return true;
            }
        }

        public static string CheckHaveZeroForOnetoTen(int MainValue)
        {
            if (MainValue.ToString().Length==1)
            {
                return "0"+MainValue.ToString();

            }
            else
            return MainValue.ToString();
        }
    }
}
