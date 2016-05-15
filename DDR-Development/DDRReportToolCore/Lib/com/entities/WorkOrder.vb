Namespace com.entities

    Public Class WorkOrder

        Private _WorkOrderID As Integer = -1
        Private _Deparment_ID As Integer
        Private _DDR_Report_ID As Integer
        Private _WONumber As String
        Private _WODescription As String

        Public Property WODescription() As String
            Get
                Return _WODescription
            End Get
            Set(ByVal value As String)
                _WODescription = value
            End Set
        End Property

        Public Property WONumber() As String
            Get
                Return _WONumber
            End Get
            Set(ByVal value As String)
                _WONumber = value
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


        Public Property Deparment_ID() As Integer
            Get
                Return _Deparment_ID
            End Get
            Set(ByVal value As Integer)
                _Deparment_ID = value
            End Set
        End Property

        Public Property WorkOrderID() As Integer
            Get
                Return _WorkOrderID
            End Get
            Set(ByVal value As Integer)
                _WorkOrderID = value
            End Set
        End Property



    End Class
End Namespace