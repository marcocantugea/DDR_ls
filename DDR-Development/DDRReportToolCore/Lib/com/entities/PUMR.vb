
Namespace com.entities
    Public Class PUMR

        Private _PRUM_ID As Integer = -1
        Private _DDR_Report_ID As Integer
        Private _MRNumber As String
        Private _DateIssued As String
        Private _MRDesc As String
        Private _Status As String


        Public Property Status() As String
            Get
                Return _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property

        Public Property MRDesc() As String
            Get
                Return _MRDesc
            End Get
            Set(ByVal value As String)
                _MRDesc = value
            End Set
        End Property

        Public Property DateIssued() As String
            Get
                Return _DateIssued
            End Get
            Set(ByVal value As String)
                _DateIssued = value
            End Set
        End Property

        Public Property MRNumber() As String
            Get
                Return _MRNumber
            End Get
            Set(ByVal value As String)
                _MRNumber = value
            End Set
        End Property

        Public Property DDR_Report_ID() As Integer
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As Integer)
                _DDR_Report_ID = value
            End Set
        End Property

        Public Property PRUM_ID() As Integer
            Get
                Return _PRUM_ID
            End Get
            Set(ByVal value As Integer)
                _PRUM_ID = value
            End Set
        End Property


    End Class
End Namespace