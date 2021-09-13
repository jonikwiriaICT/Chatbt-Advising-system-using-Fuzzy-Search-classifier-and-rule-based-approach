using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Data;
using System.Data.SqlClient;

namespace AdvisingSystemLibrary
{
    public partial class SysAdminModel: _Database
    {
        public string Message = string.Empty;
        public string FirstCa = string.Empty;
        public string SecondCa = string.Empty;
        public string ThirdCa = string.Empty;
        public string Exam = string.Empty;
        public string Total = string.Empty;
        public string Grade = string.Empty;
        public string Remark = string.Empty;
        public string PMessage = string.Empty;
        public string StudentName = string.Empty;
        public bool GetMessage(string Text)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT DISTINCT top (1) replies, fms.score, SOUNDEX(queries) AS SoundexCode from tbl_chat CROSS APPLY(select dbo.FuzzyMatchString(@s1, queries) AS score) AS fms ORDER by fms.score desc";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@s1", Text);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                Message = ds.Tables[0].Rows[0]["replies"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Chat for Performance
        public bool GetPerformance(string Text, string RecID)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT DISTINCT top (1) StudentName, FirstCa, SecondCA, ThirdCA, Exam, Grade, Remark, Total, fms.score, CourseName, CourseCode, SOUNDEX(CourseCode + CourseName ) AS SoundexCode from qry_statistics CROSS APPLY(select dbo.FuzzyMatchString(@s1, CourseCode) AS score) AS fms WHERE MaxSt=@RecID ORDER by fms.score desc";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@s1", Text);
                objCmd.Parameters.AddWithValue("@RecID", RecID);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                if(int.Parse (ds.Tables[0].Rows[0]["Total"].ToString())  < 45)
                {
                    Message = "Please i am not that intelligent. Emmanuel Edet is still training me. Remember, the course you told me to check for you may not be found in my brain. So this is the course you mostly like did." + "</br>" + "Your name is:" + " " + ds.Tables[0].Rows[0]["StudentName"].ToString() + " </br>" + "Course Title :" + ds.Tables[0].Rows[0]["CourseName"].ToString() + " " + "</br>" + "Course Code: " + ds.Tables[0].Rows[0]["CourseCode"].ToString() + "" + "</br>" + "Your First CA:" + " " + ds.Tables[0].Rows[0]["FirstCa"].ToString() + " </br>" + "Your Second CA:" + " " + ds.Tables[0].Rows[0]["SecondCa"].ToString() + " </br>" + "Your Third CA:" + " " + ds.Tables[0].Rows[0]["ThirdCa"].ToString() + " </br>" + "Your Exam :" + " " + ds.Tables[0].Rows[0]["Exam"].ToString() + " </br>" + "Your Grade:" + " " + ds.Tables[0].Rows[0]["Grade"].ToString() + " </br>" + "Your Remark:" + " " + ds.Tables[0].Rows[0]["Remark"].ToString() + "</br>" + " " + "Your grade is so poor. I wish i can help you. What you will do is to meet the lecturer because from my evaluation, the lecturer is friendly. Just try to study and remember God in everyting you do.";
                    return true;
                }
                else  if(int.Parse (ds.Tables[0].Rows[0]["Total"].ToString()) <=50 ){
                    Message = "Please i am not that intelligent. Emmanuel Edet is still training me. Remember, the course you told me to check for you may not be found in my brain. So this is the course you mostly like did." + "</br>" + "Your name is:" + " " + ds.Tables[0].Rows[0]["StudentName"].ToString() + " </br>" + "Course Title :" + ds.Tables[0].Rows[0]["CourseName"].ToString() + " " + "</br>" + "Course Code: " + ds.Tables[0].Rows[0]["CourseCode"].ToString() + "" + "</br>" + "Your First CA:" + " " + ds.Tables[0].Rows[0]["FirstCa"].ToString() + " </br>" + "Your Second CA:" + " " + ds.Tables[0].Rows[0]["SecondCa"].ToString() + " </br>" + "Your Third CA:" + " " + ds.Tables[0].Rows[0]["ThirdCa"].ToString() + " </br>" + "Your Exam :" + " " + ds.Tables[0].Rows[0]["Exam"].ToString() + " </br>" + "Your Grade:" + " " + ds.Tables[0].Rows[0]["Grade"].ToString() + " </br>" + "Your Remark:" + " " + ds.Tables[0].Rows[0]["Remark"].ToString() + "</br>" + " " + "Your grade is moderate. I wish i can help you. What you will do is to meet the lecturer because from my evaluation, the lecturer is friendly. Just try to study and remember God in everyting you do.";
                    return true;
                }
                else if (int.Parse(ds.Tables[0].Rows[0]["Total"].ToString()) <= 60)
                {
                    Message = "Please i am not that intelligent. Emmanuel Edet is still training me. Remember, the course you told me to check for you may not be found in my brain. So this is the course you mostly like did." + "</br>" + "Your name is:" + " " + ds.Tables[0].Rows[0]["StudentName"].ToString() + " </br>" + "Course Title :" + ds.Tables[0].Rows[0]["CourseName"].ToString() + " " + "</br>" + "Course Code: " + ds.Tables[0].Rows[0]["CourseCode"].ToString() + "" + "</br>" + "Your First CA:" + " " + ds.Tables[0].Rows[0]["FirstCa"].ToString() + " </br>" + "Your Second CA:" + " " + ds.Tables[0].Rows[0]["SecondCa"].ToString() + " </br>" + "Your Third CA:" + " " + ds.Tables[0].Rows[0]["ThirdCa"].ToString() + " </br>" + "Your Exam :" + " " + ds.Tables[0].Rows[0]["Exam"].ToString() + " </br>" + "Your Grade:" + " " + ds.Tables[0].Rows[0]["Grade"].ToString() + " </br>" + "Your Remark:" + " " + ds.Tables[0].Rows[0]["Remark"].ToString() + "</br>" + " " + "Your grade is good. You need to study hard. What you will do is to meet the lecturer because from my evaluation, the lecturer is friendly. Just try to study and remember God in everyting you do.";
                    return true;
                }
                else if (int.Parse(ds.Tables[0].Rows[0]["Total"].ToString()) <= 70)
                {
                   
                    Message = "Please i am not that intelligent. Emmanuel Edet is still training me. Remember, the course you told me to check for you may not be found in my brain. So this is the course you mostly like did." + "</br>" + "Your name is:" + " " + ds.Tables[0].Rows[0]["StudentName"].ToString() + " </br>" + "Course Title :" + ds.Tables[0].Rows[0]["CourseName"].ToString() + " " + "</br>" + "Course Code: " + ds.Tables[0].Rows[0]["CourseCode"].ToString() + "" + "</br>" + "Your First CA:" + " " + ds.Tables[0].Rows[0]["FirstCa"].ToString() + " </br>" + "Your Second CA:" + " " + ds.Tables[0].Rows[0]["SecondCa"].ToString() + " </br>" + "Your Third CA:" + " " + ds.Tables[0].Rows[0]["ThirdCa"].ToString() + " </br>" + "Your Exam :" + " " + ds.Tables[0].Rows[0]["Exam"].ToString() + " </br>" + "Your Grade:" + " " + ds.Tables[0].Rows[0]["Grade"].ToString() + " </br>" + "Your Remark:" + " " + ds.Tables[0].Rows[0]["Remark"].ToString() + "</br>" + " " + "Your grade is excellent. Keep it up. What you will do is to meet the lecturer because from my evaluation, the lecturer is friendly. Just try to study and remember God in everyting you do.";
                    return true;
                }
                else
                {
                    Message = "Please i am not that intelligent. Emmanuel Edet is still training me. Remember, the course you told me to check for you may not be found in my brain. So this is the course you mostly like did." + "</br>" + "Your name is:" + " " + ds.Tables[0].Rows[0]["StudentName"].ToString() + " </br>" + "Course Title :" + ds.Tables[0].Rows[0]["CourseName"].ToString() + " " + "</br>" + "Course Code: " + ds.Tables[0].Rows[0]["CourseCode"].ToString() + "" + "</br>" + "Your First CA:" + " " + ds.Tables[0].Rows[0]["FirstCa"].ToString() + " </br>" + "Your Second CA:" + " " + ds.Tables[0].Rows[0]["SecondCa"].ToString() + " </br>" + "Your Third CA:" + " " + ds.Tables[0].Rows[0]["ThirdCa"].ToString() + " </br>" + "Your Exam :" + " " + ds.Tables[0].Rows[0]["Exam"].ToString() + " </br>" + "Your Grade:" + " " + ds.Tables[0].Rows[0]["Grade"].ToString() + " </br>" + "Your Remark:" + " " + ds.Tables[0].Rows[0]["Remark"].ToString() + "</br>" + " " + "Your grade is excellent. Keep it up. What you will do is to meet the lecturer because from my evaluation, the lecturer is friendly. Just try to study and remember God in everyting you do.";
                    return true;
                }

               
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool GetPerformanceEvaluation(string Text, string RecID)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT DISTINCT  Names, matric_no, course_id, Total, Semester, Session, [BF Total Credit] as BFTotalCredit,[BF Total Grade] as BFTotalGrade, [BF Grade Point] as BFGradePoint, [Current Total Credit] as CurrentTotalCredit,[Current Grade] as CurrentGrade, [Current Grade Point] as CurrentGradePoint, fms.score, SOUNDEX(Session + Semester ) AS SoundexCode from qryPerformance CROSS APPLY(select dbo.FuzzyMatchString(@s1, Session + Semester) AS score) AS fms WHERE Mt=@RecID ORDER by fms.score desc";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@s1", Text);
                objCmd.Parameters.AddWithValue("@RecID", RecID);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
               
                    Message = "This is  your evaluation score. " + "</br>" + "Your name is:" + " " + ds.Tables[0].Rows[0]["Names"].ToString()  + "</br>" + " " + "Your Matric Number is:" + " " + ds.Tables[0].Rows[0]["matric_no"].ToString() + "</br>"  + "Course ID: " + ds.Tables[0].Rows[0]["course_id"].ToString() + "" + "</br>" + "Semester:" + " " + ds.Tables[0].Rows[0]["Semester"].ToString() + " </br>" + "Your Session" + " " + ds.Tables[0].Rows[0]["Session"].ToString() + " </br>" + "Total Grade: " + ds.Tables[0].Rows[0]["Total"].ToString () + " " + "</br>" + "Brought Forward Total Credit" + " " + ds.Tables[0].Rows[0]["BFTotalCredit"].ToString() + " </br>" + "Brought Forward Total Grade :" + " " + ds.Tables[0].Rows[0]["BFTotalGrade"].ToString() + " </br>" + " Brought Forware Grade Point: " + ds.Tables[0].Rows[0]["BFGradePoint"].ToString () + " " + "</br>" + "Current Total Credit" + " " + ds.Tables[0].Rows[0]["CurrentTotalCredit"].ToString() + " </br>" + "Current Grade:" + " " + ds.Tables[0].Rows[0]["CurrentGrade"].ToString() + "</br>" + " " + ds.Tables[0].Rows[0]["CurrentGradePoint"].ToString () + " " + "</br> " + "";
                    return true;
                
                    
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Chat for Course Registration
        public bool GetCourseRegistration(string Text)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT DISTINCT top (1) replies, fms.score, SOUNDEX(queries) AS SoundexCode from tbl_chat CROSS APPLY(select dbo.FuzzyMatchString(@s1, queries) AS score) AS fms ORDER by fms.score desc";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@s1", Text);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                Message = ds.Tables[0].Rows[0]["replies"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Chat for Check Score
        public bool GetScore(string Text)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT DISTINCT top (1) replies, fms.score, SOUNDEX(queries) AS SoundexCode from tbl_chat CROSS APPLY(select dbo.FuzzyMatchString(@s1, queries) AS score) AS fms ORDER by fms.score desc";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@s1", Text);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                Message = ds.Tables[0].Rows[0]["replies"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Chat for Contact Supervisor
        public bool GetSupervisior(string Text)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT DISTINCT top (1) replies, fms.score, SOUNDEX(queries) AS SoundexCode from tbl_chat CROSS APPLY(select dbo.FuzzyMatchString(@s1, queries) AS score) AS fms ORDER by fms.score desc";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@s1", Text);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                Message = ds.Tables[0].Rows[0]["replies"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Chat for Advise on how to read
        public bool GetHowToRead(string Text)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "SELECT DISTINCT top (1) replies, fms.score, SOUNDEX(queries) AS SoundexCode from tbl_chat CROSS APPLY(select dbo.FuzzyMatchString(@s1, queries) AS score) AS fms ORDER by fms.score desc";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@s1", Text);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                Message = ds.Tables[0].Rows[0]["replies"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
