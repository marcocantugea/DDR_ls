Namespace com.entities

    Public Class WorkOrder

        Private _WorkOrderID As Integer = -1
        Private _Deparment_ID As Integer
        Private _DDR_Report_ID As Integer
        Private _WONumber As String
        Private _WODescription As String


        'Agregado el dia 5-Ago-2017
        'Nuevos campos para la funcionalidad del F1
        Private _WODescriptionSpanish As String
        Private _WOToF1 As Boolean
        Private _WOCorrective As Boolean
        Private _WOPreventive As Boolean

        'Agregado el dia 5-Ago-2017
        'Nuevos campos para la funcionalidad del F1
        Public Property WOPreventive As Boolean
            Get
                Return _WOPreventive
            End Get
            Set(value As Boolean)
                _WOPreventive = value
            End Set
        End Property

        Public Property WOCorrective As Boolean
            Get
                Return _WOCorrective
            End Get
            Set(value As Boolean)
                _WOCorrective = value
            End Set
        End Property

        Public Property WOToF1() As Boolean
            Get
                Return _WOToF1
            End Get
            Set(value As Boolean)
                _WOToF1 = value
            End Set
        End Property

        Public Property WODescriptionSpanish() As String
            Get
                Return _WODescriptionSpanish
            End Get
            Set(value As String)
                _WODescriptionSpanish = value
            End Set
        End Property



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