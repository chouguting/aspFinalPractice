
Imports System.Data
Imports System.Data.SqlClient

Partial Class final
    Inherits System.Web.UI.Page


    Protected Sub newCookieButton_Click(sender As Object, e As EventArgs) Handles newCookieButton.Click
        Response.Cookies("User")("Name")=Server.UrlEncode("周固廷")
        Response.Cookies("User")("ID")=Server.UrlEncode("00857005")
        Response.Cookies("User")("EMail")=Server.UrlEncode("chouguting@gmail.com")
        Response.Cookies("User").Expires=DateAdd("D",10,Today)
        cookieLabel.Text="成功建立多鍵Cookie"

    End Sub

    Protected Sub readCookieButton_Click(sender As Object, e As EventArgs) Handles readCookieButton.Click
        Dim name,idNum,email As String
        If Request.Cookies("User") IsNot Nothing
            name=Server.UrlDecode(Request.Cookies("User")("Name"))
            idNum=Server.UrlDecode(Request.Cookies("User")("ID"))
            email=Server.UrlDecode(Request.Cookies("User")("EMail"))
            cookieLabel.Text = "name = " & name & "<br/>"
            cookieLabel.Text &= "ID = " & idNum & "<br/>"
            cookieLabel.Text &= "E-mail = " & email & "<br/>"
        Else 
            cookieLabel.Text="多鍵Cookie不存在"
        End If
    End Sub

    Protected Sub deleteCookieButton_Click(sender As Object, e As EventArgs) Handles deleteCookieButton.Click
        Response.Cookies("User").Expires = DateAdd("D",-365,Today)
        cookieLabel.Text="成功刪除多鍵Cookie"
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objCon As SqlConnection
        Dim objDataAdapter As SqlDataAdapter
        Dim strDbCon, strSQL As String
        strDbCon = "Data Source=(LocalDB)\MSSQLLOCALDB;" &
                   "AttachDbFilename=" &
                   Server.MapPath("App_Data\School_final.mdf") &
                   ";Integrated Security=True"
        objCon = New SqlConnection(strDbCon)
        objCon.Open()

        strSQL = "SELECT * FROM Classes"
        objDataAdapter = New SqlDataAdapter(strSQL, objCon)
        Dim objDataSet As DataSet = New DataSet()
        objDataAdapter.Fill(objDataSet, "Classes")
        Dim objRow As DataRow
        dataSetLabel.Text="資料紀錄表" & "<hr/>" 
        For Each objRow In objDataSet.Tables("Classes").Rows
            dataSetLabel.Text &= objRow("eid") & "-"
            dataSetLabel.Text &= objRow("sid") & "-"
            dataSetLabel.Text &= objRow("c_no") & "-"
            dataSetLabel.Text &= objRow("room") & "<br/>"
        Next
        objCon.Close()
    End Sub



    Protected Sub userNameCustomValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles userNameCustomValidator.ServerValidate
        If usernameTextBox.Text.StartsWith("admin")
            args.IsValid=False
        ElseIf usernameTextBox.Text.Contains("root")
            args.IsValid=False
        Else 
            args.IsValid=True
        End If
    End Sub

    Protected Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click
        if Page.IsValid
            userNameLabel.Text="使用者名稱=" & usernameTextBox.Text
        End If
    End Sub

    Protected Sub showInstructorButton_Click(sender As Object, e As EventArgs) Handles showInstructorButton.Click
        Dim objCon As SqlConnection
        Dim objCmd As SqlCommand
        Dim objDR As SqlDataReader
        Dim strDbCon, strSQL As String
        strDbCon = "Data Source=(LocalDB)\MSSQLLOCALDB;" &
                   "AttachDbFilename=" &
                   Server.MapPath("App_Data\School_final.mdf") &
                   ";Integrated Security=True"
        objCon = New SqlConnection(strDbCon)
        objCon.Open()

        strSQL = "SELECT * FROM Instructors ORDER BY eid DESC"
        objCmd = New SqlCommand(strSQL, objCon)
        objDR = objCmd.ExecuteReader()
        If objDR.HasRows Then
            instructorLabel.Text = "資料表紀錄:<hr/>"
            Do While objDR.Read()  '讀下一列 如果有下一列
                '就印出下一列的這三個資料
                instructorLabel.Text &= objDR("eid") & "-"
                instructorLabel.Text &= objDR("name") & "-"
                instructorLabel.Text &= objDR("rank") & "-"
                instructorLabel.Text &= objDR("department") & "<br/>"
            Loop
        Else
            instructorLabel.Text = "DATABASE中沒有資料"
        End If
        objDR.Close()
        objCon.Close()
    End Sub

    Protected Sub toRightButton_Click(sender As Object, e As EventArgs) Handles toRightButton.Click
        While Not leftListBox.SelectedIndex=-1
            rightListBox.Items.Add(leftListBox.SelectedItem)
            leftListBox.Items.Remove(leftListBox.SelectedItem)
        End While
    End Sub

    Protected Sub toLeftButton_Click(sender As Object, e As EventArgs) Handles toLeftButton.Click
        While Not rightListBox.SelectedIndex=-1
            leftListBox.Items.Add(rightListBox.SelectedItem)
            rightListBox.Items.Remove(rightListBox.SelectedItem)
        End While
    End Sub


    Protected Sub departmentRadioButtonList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles departmentRadioButtonList.SelectedIndexChanged
        dataGridView.DataBind()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles browserInfoDropDownList.SelectedIndexChanged
        If browserInfoDropDownList.SelectedIndex=1
            browserInfoLabel.Text = Request.Browser.Browser
        ElseIf browserInfoDropDownList.SelectedIndex=2
            browserInfoLabel.Text = Request.Browser.MajorVersion
        ElseIf browserInfoDropDownList.SelectedIndex=3
            browserInfoLabel.Text = Request.Browser.Cookies
        ElseIf browserInfoDropDownList.SelectedIndex=4
            browserInfoLabel.Text = Request.Browser.JavaApplets
        End If
    End Sub

    Protected Sub showAll_Click(sender As Object, e As EventArgs) Handles showAll.Click
        Const BR = "<br/>" '換行常數
        Dim hbc As HttpBrowserCapabilities = Request.Browser
        browserInfoLabel.Text &= "瀏覽器名稱: " & hbc.Browser & BR
        browserInfoLabel.Text &= "主版本編號: " & hbc.MajorVersion & BR
        browserInfoLabel.Text &= "是否支援Cookies: " & hbc.Cookies & BR
        browserInfoLabel.Text &= "是否支援Java Applets: " & hbc.JavaApplets & BR
    End Sub
End Class
