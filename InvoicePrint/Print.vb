Imports Microsoft.Reporting.WinForms

Public Class Print
    Public _Payer As String
    Public _Vessel As String
    Public _Blno As String
    Public _Loadport As String
    Public _Disport As String
    Public _Desport As String
    Public _Bankname As String
    Public _Bankaccount As String
    Public _IOC As String
    Public _Tax As String
    Public _Reviewer As String
    Public _Maker As String
    Public _PrintDate As String
    Public _SailedDate As String
    Public _BusinessSeal As String
    Public _CNYRMB As String
    Public _NUMRMB As String
    Public _Particulars As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Payer As String
        Get
            Return _Payer
        End Get
        Set(ByVal Value As String)
            _Payer = Value
        End Set
    End Property

    Public Property Vessel As String
        Get
            Return _Vessel
        End Get
        Set(ByVal Value As String)
            _Vessel = Value
        End Set
    End Property

    Public Property Blno As String
        Get
            Return _Blno
        End Get
        Set(ByVal Value As String)
            _Blno = Value
        End Set
    End Property

    Public Property Loadport As String
        Get
            Return _Loadport
        End Get
        Set(ByVal Value As String)
            _Loadport = Value
        End Set
    End Property

    Public Property Disport As String
        Get
            Return _Disport
        End Get
        Set(ByVal Value As String)
            _Disport = Value
        End Set
    End Property

    Public Property Desport As String
        Get
            Return _Desport
        End Get
        Set(ByVal Value As String)
            _Desport = Value
        End Set
    End Property

    Public Property Bankname As String
        Get
            Return _Bankname
        End Get
        Set(ByVal Value As String)
            _Bankname = Value
        End Set
    End Property

    Public Property Bankaccount As String
        Get
            Return _Bankaccount
        End Get
        Set(ByVal Value As String)
            _Bankaccount = Value
        End Set
    End Property

    Public Property IOC As String
        Get
            Return _IOC
        End Get
        Set(ByVal Value As String)
            _IOC = Value
        End Set
    End Property

    Public Property Tax As String
        Get
            Return _Tax
        End Get
        Set(ByVal Value As String)
            _Tax = Value
        End Set
    End Property

    Public Property Reviewer As String
        Get
            Return _Reviewer
        End Get
        Set(ByVal Value As String)
            _Reviewer = Value
        End Set
    End Property

    Public Property Maker As String
        Get
            Return _Maker
        End Get
        Set(ByVal Value As String)
            _Maker = Value
        End Set
    End Property

    Public Property Printdate As String
        Get
            Return _Printdate
        End Get
        Set(ByVal Value As String)
            _Printdate = Value
        End Set
    End Property

    Public Property SailedDate As String
        Get
            Return _SailedDate
        End Get
        Set(ByVal Value As String)
            _SailedDate = Value
        End Set
    End Property

    Public Property BusinessSeal As String
        Get
            Return _BusinessSeal
        End Get
        Set(ByVal Value As String)
            _BusinessSeal = Value
        End Set
    End Property

    Public Property CNYRMB As String
        Get
            Return _CNYRMB
        End Get
        Set(ByVal Value As String)
            _CNYRMB = Value
        End Set
    End Property

    Public Property NUMRMB As String
        Get
            Return _NUMRMB
        End Get
        Set(ByVal Value As String)
            _NUMRMB = Value
        End Set
    End Property

    Public Property Particulars As DataTable
        Get
            Return _Particulars
        End Get
        Set(ByVal Value As DataTable)
            _Particulars = Value
        End Set
    End Property

    Private Sub Print_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Payer", Payer))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Vessel", Vessel))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Blno", Blno))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Loadport", Loadport))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Disport", Disport))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Desport", Desport))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Bankname", Bankname))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Bankaccount", Bankaccount))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("IOC", IOC))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Tax", Tax))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Reviewer", Reviewer))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("Maker", Maker))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("PrintDate", Printdate.ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("SailedDate", SailedDate.ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("BusinessSeal", BusinessSeal))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("CNYRMB", "人民币" & CNYRMB))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("NUMRMB", NUMRMB))

        ReportViewer1.LocalReport.DataSources.Clear()
        Dim rds As New ReportDataSource("DataSet1", Particulars)
        ReportViewer1.LocalReport.DataSources.Add(rds)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class