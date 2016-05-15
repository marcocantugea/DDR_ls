Namespace com.entities


    Public Class RiserProfile

        Private _IDBeacon As String
        Private _Depth As String
        Private _Temp6hrs As String
        Private _Temp12hrs As String
        Private _Temp18hrs As String
        Private _Temp24hrs As String
        Private _Current6hrs As String
        Private _Current12hrs As String
        Private _Current18hrs As String
        Private _Current24hrs As String
        Private _Direction6hrs As String
        Private _Direction12hrs As String
        Private _Direction18hrs As String
        Private _Direction24hrs As String
        Private _IDRiserProfile As Integer
        Private _DDR_Report_ID As Integer

        Public Property DDR_Report_ID() As Integer
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As Integer)
                _DDR_Report_ID = value
            End Set
        End Property

        Public Property IDBeacon() As String
            Get
                Return _IDBeacon
            End Get
            Set(ByVal value As String)
                _IDBeacon = value
            End Set
        End Property


        Public Property Depth() As String
            Get
                Return _Depth
            End Get
            Set(ByVal value As String)
                _Depth = value
            End Set
        End Property

        Public Property Temp6hrs() As String
            Get
                Return _Temp6hrs
            End Get
            Set(ByVal value As String)
                _Temp6hrs = value
            End Set
        End Property
        Public Property Temp12hrs() As String
            Get
                Return _Temp12hrs
            End Get
            Set(ByVal value As String)
                _Temp12hrs = value
            End Set
        End Property
        Public Property Temp18hrs() As String
            Get
                Return _Temp18hrs
            End Get
            Set(ByVal value As String)
                _Temp18hrs = value
            End Set
        End Property
        Public Property Temp24hrs() As String
            Get
                Return _Temp24hrs
            End Get
            Set(ByVal value As String)
                _Temp24hrs = value
            End Set
        End Property

        Public Property Current6hrs() As String
            Get
                Return _Current6hrs
            End Get
            Set(ByVal value As String)
                _Current6hrs = value
            End Set
        End Property
        Public Property Current12hrs() As String
            Get
                Return _Current12hrs
            End Get
            Set(ByVal value As String)
                _Current12hrs = value
            End Set
        End Property
        Public Property Current18hrs() As String
            Get
                Return _Current18hrs
            End Get
            Set(ByVal value As String)
                _Current18hrs = value
            End Set
        End Property
        Public Property Current24hrs() As String
            Get
                Return _Current24hrs
            End Get
            Set(ByVal value As String)
                _Current24hrs = value
            End Set
        End Property

        Public Property Direction6hrs() As String
            Get
                Return _Direction6hrs
            End Get
            Set(ByVal value As String)
                _Direction6hrs = value
            End Set
        End Property

        Public Property Direction12hrs() As String
            Get
                Return _Direction12hrs
            End Get
            Set(ByVal value As String)
                _Direction12hrs = value
            End Set
        End Property

        Public Property Direction18hrs() As String
            Get
                Return _Direction18hrs
            End Get
            Set(ByVal value As String)
                _Direction18hrs = value
            End Set
        End Property

        Public Property Direction24hrs() As String
            Get
                Return _Direction24hrs
            End Get
            Set(ByVal value As String)
                _Direction24hrs = value
            End Set
        End Property

    End Class
End Namespace