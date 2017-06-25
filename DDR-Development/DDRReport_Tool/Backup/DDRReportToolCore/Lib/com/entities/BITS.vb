
Namespace com.entities
    Public Class BITS

        Private _BITS_ID As Integer = -1
        Private _No As String
        Private _Size As String
        Private _Make As String
        Private _Serial As String
        Private _Jets As String
        Private _TFA As String
        Private _Out As String
        Private _In As String
        Private _Mtrs As String
        Private _Hrs As String
        Private _Comments As String
        Private _DDR_Report_ID As Integer
        Private _Bit_type As String

        Public Property Bit_type() As String
            Get
                Return _Bit_type
            End Get
            Set(ByVal value As String)
                _Bit_type = value
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

        Public Property bit_Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property
        Public Property bit_Hrs() As String
            Get
                Return _Hrs
            End Get
            Set(ByVal value As String)
                _Hrs = value
            End Set
        End Property
        Public Property bit_Mtrs() As String
            Get
                Return _Mtrs
            End Get
            Set(ByVal value As String)
                _Mtrs = value
            End Set
        End Property

        Public Property bit_In() As String
            Get
                Return _In
            End Get
            Set(ByVal value As String)
                _In = value
            End Set
        End Property
        Public Property bit_Out() As String
            Get
                Return _Out
            End Get
            Set(ByVal value As String)
                _Out = value
            End Set
        End Property
        Public Property bit_TFA() As String
            Get
                Return _TFA
            End Get
            Set(ByVal value As String)
                _TFA = value
            End Set
        End Property
        Public Property bit_Jets() As String
            Get
                Return _Jets
            End Get
            Set(ByVal value As String)
                _Jets = value
            End Set
        End Property
        Public Property bit_Serial() As String
            Get
                Return _Serial
            End Get
            Set(ByVal value As String)
                _Serial = value
            End Set
        End Property
        Public Property bit_Make() As String
            Get
                Return _Make
            End Get
            Set(ByVal value As String)
                _Make = value
            End Set
        End Property
        Public Property bit_Size() As String
            Get
                Return _Size
            End Get
            Set(ByVal value As String)
                _Size = value
            End Set
        End Property
        Public Property bit_No() As String
            Get
                Return _No
            End Get
            Set(ByVal value As String)
                _No = value
            End Set
        End Property
        Public Property BITS_ID() As Integer
            Get
                Return _BITS_ID
            End Get
            Set(ByVal value As Integer)
                _BITS_ID = value
            End Set
        End Property


    End Class
End Namespace