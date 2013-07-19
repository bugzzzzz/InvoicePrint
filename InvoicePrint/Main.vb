Imports System.Xml

Public Class Main
    Private XMLFileName As String = Application.StartupPath & "\Data.xml"
    Dim ds As New DataSet
    Dim dr As DataRow
    Dim dt As DataTable
    Dim amount As Single

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dataset_Init()
        Screen_Init()
        ToolTip()

        'Dim aa As DataGridViewTextBoxColumn

    End Sub

    ''' <summary>
    ''' 测试
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub bbb()
        Dim ds As New DataSet
        ds.DataSetName = "Invoice"

        Dim dt As New DataTable
        dt.TableName = "Payer"
        dt.Columns.Add("value", System.Type.GetType("System.String"))
        dt.Columns.Add("Locked", System.Type.GetType("System.Boolean"))
        Dim dr As DataRow
        dr = dt.NewRow()
        dr("value") = "test"
        dr("locked") = False
        dt.Rows.Add(dr)
        dr = dt.NewRow
        dr("value") = "bbb"
        dr("locked") = True
        dt.Rows.Add(dr)


        Dim dt1 As New DataTable
        dt1.TableName = "vessel"
        dt1.Columns.Add("value", System.Type.GetType("System.String"))
        dt1.Columns.Add("locked", System.Type.GetType("System.Boolean"))
        dr = dt1.NewRow
        dr("value") = "aaaa"
        dr("locked") = False
        dt1.Rows.Add(dr)

        ds.Tables.Add(dt)
        ds.Tables.Add(dt1)
        ds.WriteXml(XMLFileName)
        'MessageBox.Show(ds.Tables.ToString)

    End Sub

    ''' <summary>
    ''' 测试
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ccc()
        'Dim XMLFileName As String = Application.StartupPath & "\Data.xml"
        'Dim ds As New DataSet

        
        'dt = ds.Tables("vessel")
        'dr = dt.Select("locked=false", "locked")

        'MessageBox.Show(dt.Columns.Count.ToString)
        'For Each dr In dt.Rows
        'If dr.Count > 0 Then
        'MessageBox.Show(dr(0)("value"))
        'Next
        'End If
    End Sub

    Private Sub Dataset_Init()
        Dim drs() As DataRow
        ds.ReadXml(XMLFileName)
        Dim dr As DataRow
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''付款单位
        Dim PayerSource As New AutoCompleteStringCollection()
        dt = ds.Tables("payer")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            PayerSource.Add(dr("value"))
        Next
        TextBox1.AutoCompleteCustomSource = PayerSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox1.Checked = drs(0)("Locked")
            TextBox1.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''船名航次
        Dim VesselSource As New AutoCompleteStringCollection
        dt = ds.Tables("vessel")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            VesselSource.Add(dr("value"))
        Next
        TextBox2.AutoCompleteCustomSource = VesselSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox3.Checked = drs(0)("Locked")
            TextBox2.Text = drs(0)("value")
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''提单号
        Dim BlnoSource As New AutoCompleteStringCollection
        dt = ds.Tables("Blno")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            BlnoSource.Add(dr("value"))
        Next
        TextBox3.AutoCompleteCustomSource = BlnoSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox4.Checked = drs(0)("Locked")
            TextBox3.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''起运港
        Dim LoadportSource As New AutoCompleteStringCollection
        dt = ds.Tables("Loadport")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            LoadportSource.Add(dr("value"))
        Next
        TextBox4.AutoCompleteCustomSource = LoadportSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox6.Checked = drs(0)("Locked")
            TextBox4.Text = drs(0)("value")
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''卸货港
        Dim DisportSource As New AutoCompleteStringCollection
        dt = ds.Tables("Disport")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            DisportSource.Add(dr("value"))
        Next
        TextBox5.AutoCompleteCustomSource = DisportSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox7.Checked = drs(0)("Locked")
            TextBox5.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''目的港
        Dim DesportSource As New AutoCompleteStringCollection
        dt = ds.Tables("Desport")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            DesportSource.Add(dr("value"))
        Next
        TextBox6.AutoCompleteCustomSource = DesportSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox8.Checked = drs(0)("Locked")
            TextBox6.Text = drs(0)("value")
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''银行名称
        Dim BanknameSource As New AutoCompleteStringCollection
        dt = ds.Tables("Bankname")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            BanknameSource.Add(dr("value"))
        Next
        TextBox7.AutoCompleteCustomSource = BanknameSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox14.Checked = drs(0)("Locked")
            TextBox7.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''银行账户
        Dim BankaccountSource As New AutoCompleteStringCollection
        dt = ds.Tables("Bankaccount")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            BankaccountSource.Add(dr("value"))
        Next
        TextBox8.AutoCompleteCustomSource = BankaccountSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox13.Checked = drs(0)("Locked")
            TextBox8.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''工商登记号
        Dim IOCSource As New AutoCompleteStringCollection
        dt = ds.Tables("IOC")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            IOCSource.Add(dr("value"))
        Next
        TextBox9.AutoCompleteCustomSource = IOCSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox12.Checked = drs(0)("Locked")
            TextBox9.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''税务登记号
        Dim TaxSource As New AutoCompleteStringCollection
        dt = ds.Tables("Tax")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            TaxSource.Add(dr("value"))
        Next
        TextBox10.AutoCompleteCustomSource = TaxSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox11.Checked = drs(0)("Locked")
            TextBox10.Text = drs(0)("value")
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''复核人
        Dim ReviewerSource As New AutoCompleteStringCollection
        dt = ds.Tables("Reviewer")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            ReviewerSource.Add(dr("value"))
        Next
        TextBox11.AutoCompleteCustomSource = ReviewerSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox10.Checked = drs(0)("Locked")
            TextBox11.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''制单人
        Dim MakerSource As New AutoCompleteStringCollection
        dt = ds.Tables("Maker")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            MakerSource.Add(dr("value"))
        Next
        TextBox12.AutoCompleteCustomSource = MakerSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox9.Checked = drs(0)("Locked")
            TextBox12.Text = drs(0)("value")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''企业签章
        Dim BusinessSealSource As New AutoCompleteStringCollection
        dt = ds.Tables("BusinessSeal")
        drs = dt.Select("value <> ''", "value")
        For Each dr In drs
            BusinessSealSource.Add(dr("value"))
        Next
        TextBox13.AutoCompleteCustomSource = BusinessSealSource
        drs = dt.Select("locked=true")
        If drs.Count = 1 Then
            CheckBox2.Checked = drs(0)("Locked")
            TextBox13.Text = drs(0)("value")
        End If
    End Sub

    Private Sub ToolTip()
        ToolTip1.SetToolTip(Me.CheckBox1, "把当前值设为默认值")           '付款单位
        'ToolTip1.SetToolTip(Me.TextBox1, "bbb")
    End Sub

    Private Sub Screen_Init()
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
    End Sub

    Private Sub Xml_Read()
        Dim xmldoc As New XmlDocument
        'Dim dt As DataTable
        'Dim dr As DataRow
        'Dim ds As DataSet

        My.Computer.FileSystem.DeleteFile(XMLFileName)

        
        Try
            xmldoc.Load(XMLFileName)
        Catch
            If Err.Number = 53 Then
                Xml_Create_XMLDocument()
                xmldoc.Load(XMLFileName)
            Else
                MessageBox.Show(Err.Description, Err.Number.ToString)
            End If
        End Try


    End Sub

    Private Sub Xml_Create_XMLDocument()
        Dim xmldoc As New XmlDocument

        Dim xe_Invoice As XmlElement = xmldoc.CreateElement("Inovice")
        Dim xe_payer As XmlElement = xmldoc.CreateElement("Payer")
        Dim xe_vessel As XmlElement = xmldoc.CreateElement("Vessel")
        Dim xe_blno As XmlElement = xmldoc.CreateElement("Blno")
        Dim xe_loadport As XmlElement = xmldoc.CreateElement("Loadport")
        Dim xe_disport As XmlElement = xmldoc.CreateElement("Disport")
        Dim xe_desport As XmlElement = xmldoc.CreateElement("Desport")
        Dim xe_bankname As XmlElement = xmldoc.CreateElement("Bankname")
        Dim xe_bankaccount As XmlElement = xmldoc.CreateElement("Bankaccount")
        Dim xe_ioc As XmlElement = xmldoc.CreateElement("IOC")
        Dim xe_tax As XmlElement = xmldoc.CreateElement("Tax")
        Dim xe_reviewer As XmlElement = xmldoc.CreateElement("Reviewer")
        Dim xe_maker As XmlElement = xmldoc.CreateElement("Maker")

        'root
        xmldoc.AppendChild(xe_Invoice)

        'child
        xe_Invoice.AppendChild(xe_payer)
        xe_Invoice.AppendChild(xe_vessel)
        xe_Invoice.AppendChild(xe_blno)
        xe_Invoice.AppendChild(xe_loadport)
        xe_Invoice.AppendChild(xe_disport)
        xe_Invoice.AppendChild(xe_desport)
        xe_Invoice.AppendChild(xe_bankname)
        xe_Invoice.AppendChild(xe_bankaccount)
        xe_Invoice.AppendChild(xe_ioc)
        xe_Invoice.AppendChild(xe_tax)
        xe_Invoice.AppendChild(xe_reviewer)
        xe_Invoice.AppendChild(xe_maker)

        'data
        xe_payer.AppendChild(xmldoc.CreateElement("Value"))
        xe_payer.AppendChild(xmldoc.CreateElement("Locked"))
        xe_vessel.AppendChild(xmldoc.CreateElement("Value"))
        xe_vessel.AppendChild(xmldoc.CreateElement("Locked"))
        xe_blno.AppendChild(xmldoc.CreateElement("Value"))
        xe_blno.AppendChild(xmldoc.CreateElement("Locked"))
        xe_loadport.AppendChild(xmldoc.CreateElement("Value"))
        xe_loadport.AppendChild(xmldoc.CreateElement("Locked"))
        xe_disport.AppendChild(xmldoc.CreateElement("Value"))
        xe_disport.AppendChild(xmldoc.CreateElement("Locked"))
        xe_desport.AppendChild(xmldoc.CreateElement("Value"))
        xe_desport.AppendChild(xmldoc.CreateElement("Locked"))
        xe_bankname.AppendChild(xmldoc.CreateElement("Value"))
        xe_bankname.AppendChild(xmldoc.CreateElement("Locked"))
        xe_bankaccount.AppendChild(xmldoc.CreateElement("Value"))
        xe_bankaccount.AppendChild(xmldoc.CreateElement("Locked"))
        xe_ioc.AppendChild(xmldoc.CreateElement("Value"))
        xe_ioc.AppendChild(xmldoc.CreateElement("Locked"))
        xe_tax.AppendChild(xmldoc.CreateElement("Value"))
        xe_tax.AppendChild(xmldoc.CreateElement("Locked"))
        xe_reviewer.AppendChild(xmldoc.CreateElement("Value"))
        xe_reviewer.AppendChild(xmldoc.CreateElement("Locked"))
        xe_maker.AppendChild(xmldoc.CreateElement("Value"))
        xe_maker.AppendChild(xmldoc.CreateElement("Locked"))

        '保存到文件
        xmldoc.Save(XMLFileName)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.ReadOnly = True
        Else
            TextBox1.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            TextBox2.ReadOnly = True
        Else
            TextBox2.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            TextBox3.ReadOnly = True
        Else
            TextBox3.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            TextBox4.ReadOnly = True
        Else
            TextBox4.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            TextBox5.ReadOnly = True
        Else
            TextBox5.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            TextBox6.ReadOnly = True
        Else
            TextBox6.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            TextBox7.ReadOnly = True
        Else
            TextBox7.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = True Then
            TextBox8.ReadOnly = True
        Else
            TextBox8.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked = True Then
            TextBox9.ReadOnly = True
        Else
            TextBox9.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            TextBox10.ReadOnly = True
        Else
            TextBox10.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked = True Then
            TextBox11.ReadOnly = True
        Else
            TextBox11.ReadOnly = False
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = True Then
            TextBox12.ReadOnly = True
        Else
            TextBox12.ReadOnly = False
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Save_Value()
        'Exit Sub
        Dim i As Integer
        For i = 0 To DataGridView1.RowCount - 2
            If DataGridView1("Descriptions", i).Value = "" Then
                MessageBox.Show("收费内容不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DataGridView1("Total", i).Value = "" Then
                MessageBox.Show("金额不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Next

        Dim print1 As New Print

        print1.Payer = TextBox1.Text
        print1.Vessel = TextBox2.Text.Trim
        print1.Blno = TextBox3.Text.Trim
        print1.Loadport = TextBox4.Text.Trim
        print1.Disport = TextBox5.Text.Trim
        print1.Desport = TextBox6.Text.Trim
        print1.Bankname = TextBox7.Text.Trim
        print1.Bankaccount = TextBox8.Text.Trim
        print1.IOC = TextBox9.Text.Trim
        print1.Tax = TextBox10.Text.Trim
        print1.Reviewer = TextBox11.Text.Trim
        print1.Maker = TextBox12.Text.Trim
        print1.Printdate = DateTimePicker1.Value.Date
        print1.SailedDate = DateTimePicker2.Value.Date
        print1.BusinessSeal = TextBox13.Text.Trim
        print1.CNYRMB = sxtodx(FormatNumber(Label16.Text, , , , TriState.False))

        print1.NUMRMB = "RMB" & Label16.Text
        
        Dim dt1 As New DataTable
        Dim drs As DataRow

        dt1.Columns.Add("descriptions", System.Type.GetType("System.String"))
        dt1.Columns.Add("amount", System.Type.GetType("System.String"))
        For Each r As DataGridViewRow In DataGridView1.Rows
            drs = dt1.NewRow
            drs("descriptions") = r.Cells("Descriptions").Value
            drs("amount") = FormatNumber(r.Cells("total").Value).ToString
            dt1.Rows.Add(drs)
        Next
        dt1.TableName = "DataSet1"
        print1.Particulars = dt1
        print1.Show(Me)

    End Sub

    Private Sub Save_Value()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''付款单位
        Dim Payerdrs() As DataRow
        dt = ds.Tables("payer")
        Payerdrs = dt.Select("value='" & TextBox1.Text.Trim & "'")
        If Payerdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox1.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox1.Checked = True Then
            Payerdrs = dt.Select("value='" & TextBox1.Text.Trim & "'")
            Payerdrs(0)("Locked") = True
            Payerdrs = dt.Select("value<>'" & TextBox1.Text.Trim & "'")
            For Each drtmp As DataRow In Payerdrs
                drtmp("Locked") = False
            Next
        Else
            Payerdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Payerdrs
                drtmp("Locked") = False
            Next
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''船名航次
        Dim Vesseldrs() As DataRow
        dt = ds.Tables("Vessel")
        Vesseldrs = dt.Select("value='" & TextBox2.Text.Trim & "'")
        If Vesseldrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox2.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox3.Checked = True Then
            Vesseldrs = dt.Select("value='" & TextBox2.Text.Trim & "'")
            Vesseldrs(0)("Locked") = True
            Vesseldrs = dt.Select("value<>'" & TextBox2.Text.Trim & "'")
            For Each drtmp As DataRow In Vesseldrs
                drtmp("Locked") = False
            Next
        Else
            Vesseldrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Vesseldrs
                drtmp("Locked") = False
            Next
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''提单号
        Dim Blnodrs() As DataRow
        dt = ds.Tables("Blno")
        Blnodrs = dt.Select("value='" & TextBox3.Text.Trim & "'")
        If Blnodrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox3.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox4.Checked = True Then
            Blnodrs = dt.Select("value='" & TextBox3.Text.Trim & "'")
            Blnodrs(0)("Locked") = True
            Blnodrs = dt.Select("value<>'" & TextBox3.Text.Trim & "'")
            For Each drtmp As DataRow In Blnodrs
                drtmp("Locked") = False
            Next
        Else
            Blnodrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Blnodrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''起运港
        Dim Loadportdrs() As DataRow
        dt = ds.Tables("Loadport")
        Loadportdrs = dt.Select("value='" & TextBox4.Text.Trim & "'")
        If Loadportdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox4.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox6.Checked = True Then
            Loadportdrs = dt.Select("value='" & TextBox4.Text.Trim & "'")
            Loadportdrs(0)("Locked") = True
            Loadportdrs = dt.Select("value<>'" & TextBox4.Text.Trim & "'")
            For Each drtmp As DataRow In Loadportdrs
                drtmp("Locked") = False
            Next
        Else
            Loadportdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Loadportdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''卸货港
        Dim Disportdrs() As DataRow
        dt = ds.Tables("Disport")
        Disportdrs = dt.Select("value='" & TextBox5.Text.Trim & "'")
        If Disportdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox5.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox7.Checked = True Then
            Disportdrs = dt.Select("value='" & TextBox5.Text.Trim & "'")
            Disportdrs(0)("Locked") = True
            Disportdrs = dt.Select("value<>'" & TextBox5.Text.Trim & "'")
            For Each drtmp As DataRow In Disportdrs
                drtmp("Locked") = False
            Next
        Else
            Disportdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Disportdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''目的港
        Dim Desportdrs() As DataRow
        dt = ds.Tables("Desport")
        Desportdrs = dt.Select("value='" & TextBox6.Text.Trim & "'")
        If Desportdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox6.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox8.Checked = True Then
            Desportdrs = dt.Select("value='" & TextBox6.Text.Trim & "'")
            Desportdrs(0)("Locked") = True
            Desportdrs = dt.Select("value<>'" & TextBox6.Text.Trim & "'")
            For Each drtmp As DataRow In Desportdrs
                drtmp("Locked") = False
            Next
        Else
            Desportdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Desportdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''工商银行帐号
        Dim Banknamedrs() As DataRow
        dt = ds.Tables("Bankname")
        Banknamedrs = dt.Select("value='" & TextBox7.Text.Trim & "'")
        If Banknamedrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox7.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox14.Checked = True Then
            Banknamedrs = dt.Select("value='" & TextBox7.Text.Trim & "'")
            Banknamedrs(0)("Locked") = True
            Banknamedrs = dt.Select("value<>'" & TextBox7.Text.Trim & "'")
            For Each drtmp As DataRow In Banknamedrs
                drtmp("Locked") = False
            Next
        Else
            Banknamedrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Banknamedrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''帐号
        Dim Bankaccountdrs() As DataRow
        dt = ds.Tables("Bankaccount")
        Bankaccountdrs = dt.Select("value='" & TextBox8.Text.Trim & "'")
        If Bankaccountdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox8.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox13.Checked = True Then
            Bankaccountdrs = dt.Select("value='" & TextBox8.Text.Trim & "'")
            Bankaccountdrs(0)("Locked") = True
            Bankaccountdrs = dt.Select("value<>'" & TextBox8.Text.Trim & "'")
            For Each drtmp As DataRow In Bankaccountdrs
                drtmp("Locked") = False
            Next
        Else
            Bankaccountdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Bankaccountdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''工商登记号
        Dim IOCdrs() As DataRow
        dt = ds.Tables("IOC")
        IOCdrs = dt.Select("value='" & TextBox9.Text.Trim & "'")
        If IOCdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox9.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox12.Checked = True Then
            IOCdrs = dt.Select("value='" & TextBox9.Text.Trim & "'")
            IOCdrs(0)("Locked") = True
            IOCdrs = dt.Select("value<>'" & TextBox9.Text.Trim & "'")
            For Each drtmp As DataRow In IOCdrs
                drtmp("Locked") = False
            Next
        Else
            IOCdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In IOCdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''税务登记号
        Dim TAXdrs() As DataRow
        dt = ds.Tables("Tax")
        TAXdrs = dt.Select("value='" & TextBox10.Text.Trim & "'")
        If TAXdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox10.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox11.Checked = True Then
            TAXdrs = dt.Select("value='" & TextBox10.Text.Trim & "'")
            TAXdrs(0)("Locked") = True
            TAXdrs = dt.Select("value<>'" & TextBox10.Text.Trim & "'")
            For Each drtmp As DataRow In TAXdrs
                drtmp("Locked") = False
            Next
        Else
            TAXdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In TAXdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''复核
        Dim Reviewerdrs() As DataRow
        dt = ds.Tables("Reviewer")
        Reviewerdrs = dt.Select("value='" & TextBox11.Text.Trim & "'")
        If Reviewerdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox11.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox10.Checked = True Then
            Reviewerdrs = dt.Select("value='" & TextBox11.Text.Trim & "'")
            Reviewerdrs(0)("Locked") = True
            Reviewerdrs = dt.Select("value<>'" & TextBox11.Text.Trim & "'")
            For Each drtmp As DataRow In Reviewerdrs
                drtmp("Locked") = False
            Next
        Else
            Reviewerdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Reviewerdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''制单
        Dim Makerdrs() As DataRow
        dt = ds.Tables("Maker")
        Makerdrs = dt.Select("value='" & TextBox12.Text.Trim & "'")
        If Makerdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox12.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox9.Checked = True Then
            Makerdrs = dt.Select("value='" & TextBox12.Text.Trim & "'")
            Makerdrs(0)("Locked") = True
            Makerdrs = dt.Select("value<>'" & TextBox12.Text.Trim & "'")
            For Each drtmp As DataRow In Makerdrs
                drtmp("Locked") = False
            Next
        Else
            Makerdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In Makerdrs
                drtmp("Locked") = False
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''企业签章
        Dim BusinessSealdrs() As DataRow
        dt = ds.Tables("BusinessSeal")
        BusinessSealdrs = dt.Select("value='" & TextBox13.Text.Trim & "'")
        If BusinessSealdrs.Count < 1 Then
            dr = dt.NewRow
            dr("value") = TextBox13.Text.Trim
            dr("locked") = False
            dt.Rows.Add(dr)
        End If
        If CheckBox2.Checked = True Then
            BusinessSealdrs = dt.Select("value='" & TextBox13.Text.Trim & "'")
            BusinessSealdrs(0)("Locked") = True
            BusinessSealdrs = dt.Select("value<>'" & TextBox13.Text.Trim & "'")
            For Each drtmp As DataRow In BusinessSealdrs
                drtmp("Locked") = False
            Next
        Else
            BusinessSealdrs = dt.Select("Locked=True")
            For Each drtmp As DataRow In BusinessSealdrs
                drtmp("Locked") = False
            Next
        End If
        ds.WriteXml(XMLFileName)

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        MessageBox.Show(TextBox1.AutoCompleteCustomSource.Count)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'MessageBox.Show(sxtodx("110000111"))
        'Dim aa As New DataSet1
        'MessageBox.Show(aa.Tables("DataTable1").TableName.ToString)
        'aa.Tables("").DataSet=DataGridView1.
        'Dim dt As New DataTable
        'dt=
        End
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Dim sfont As Font
        sfont = New Font(Me.Font.FontFamily, Me.Font.Size + 1.5F, Me.Font.Style)
        Me.Font = sfont
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        Dim sfont As Font
        sfont = New Font(Me.Font.FontFamily, Me.Font.Size - 1.5F, Me.Font.Style)
        Me.Font = sfont
    End Sub

    Public Function sxtodx(ByVal XXJE As String)
        '小写转换成大写
        Dim SL As String
        Dim JE As String
        Dim m As String
        Dim dxje As String
        Dim n As Integer
        Dim j As Integer
        Dim i As Integer
        Dim w As Integer
        SL = "零壹贰叁肆伍陆柒捌玖"
        JE = "分角元拾佰仟万拾佰仟亿拾佰仟"
        m = Trim(XXJE)
        If InStr(m, ".") <= 0 Then
            m = Trim(m) + "00"
        End If
        If Len(m) - InStr(m, ".") = 1 Then
            m = m + "0"
        End If
        m = Replace(Trim(m), ".", "")
        n = Len(m)
        j = n
        dxje = ""
        For i = 1 To n
            w = Val(Mid(m, i, 1))
            If w > 0 Then
                dxje = dxje + Mid(SL, w + 1, 1)
                dxje = dxje + Mid(JE, j, 1)
            ElseIf w = 0 Then
                If Mid(JE, j, 1) = "万" Then
                    dxje = dxje + Mid(JE, j, 1)
                ElseIf Mid(JE, j, 1) = "元" Then
                    If Len(m) = 3 Then
                        dxje = dxje + "零"
                    End If
                    dxje = dxje + "元"
                    If Val(Mid(m, i + 1, 1)) > 0 And Len(m) > 3 Then
                        dxje = dxje + Mid(SL, w + 1, 1)
                    End If
                ElseIf Val(Mid(m, i + 1, 1)) > 0 Then
                    dxje = dxje + Mid(SL, w + 1, 1)
                ElseIf Val(Mid(m, i)) = 0 Then
                    If j > 10 Then dxje = dxje + "亿"
                    If (j >= 7) And (j <= 9) Then dxje = dxje + "万"
                    If j >= 3 Then dxje = dxje + "元"
                    dxje = dxje + "整"
                    Exit For
                End If
            End If
            j = j - 1
        Next
        sxtodx = dxje
    End Function

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If DataGridView1.Columns(e.ColumnIndex).HeaderText = "金额" Then
            Dim i As Integer
            amount = 0
            For i = 0 To DataGridView1.RowCount - 2
                amount = amount + DataGridView1(e.ColumnIndex, i).Value
                'MessageBox.Show(DataGridView1(e.ColumnIndex, i).Value)
            Next
            Label16.Text = FormatNumber(amount)
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox13.ReadOnly = True
        Else
            TextBox13.ReadOnly = False
        End If
    End Sub

End Class
