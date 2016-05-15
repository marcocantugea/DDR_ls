Namespace com.entities
    Public Class MarineInfo

        Private _Marine_ID As Integer = -1
        Private _AirGap As String
        Private _UsedPlayload As String
        Private _RemainingPayload As String
        Private _LastboatDrill As Date
        Private _FireDrill As Date
        Private _BOPTest As String
        Private _COMTest As String
        Private _YestStock_PotWater As String
        Private _YestStock_Diesel As String
        Private _YestStock_DrillWater As String
        Private _YestStock_LubOil As String
        Private _YestStock_Barite As String
        Private _YestStock_Bentonite As String
        Private _YestStock_Gel As String
        Private _YestStock_CementG As String
        Private _YestStock_CmtBlended As String
        Private _TodayStock_PotWater As String
        Private _TodayStock_Diesel As String
        Private _TodayStock_DrillWater As String
        Private _TodayStock_LubOil As String
        Private _TodayStock_Barite As String
        Private _TodayStock_Bentonite As String
        Private _TodayStock_Gel As String
        Private _TodayStock_CementG As String
        Private _TodayStock_CMTBlended As String
        Private _Used_PotWater As String
        Private _Used_Diesel As String
        Private _Used_DrillWater As String
        Private _Used_LubOil As String
        Private _Used_Barite As String
        Private _Used_Bentoniote As String
        Private _Used_Gel As String
        Private _Used_CementG As String
        Private _Used_CmtBlended As String
        Private _RecivedMade_PotWater As String
        Private _RecivedMade_Diesel As String
        Private _RecivedMade_DrillWater As String
        Private _RecivedMade_LubOil As String
        Private _RecivedMade_Barite As String
        Private _RecivedMade_Bentoniote As String
        Private _RecivedMade_Gel As String
        Private _RecivedMade_CementG As String
        Private _RecivedMade_CmtBlended As String
        Private _Helifuel As String
        Private _LubOil As String
        Private _Nitrogen_FullBottles As String
        Private _Nitrogen_InUse As String
        Private _Nitrogen_Empty As String
        Private _Oxygen_FullBottles As String
        Private _Oxygen_InUse As String
        Private _Oxygen_Empty As String
        Private _Acetyl_FullBottles As String
        Private _Acetyl_InUse As String
        Private _Acetyl_Empty As String
        Private _Brine As String
        Private _Base_oil As String
        Private _DDR_Report_ID As Integer
        Private _Comments As String
        Private _ToneMilesSinceLastCut As String
        Private _GeneratorsOnline As String
        Private _Thrustersonline As String


        Public Property Thrustersonline() As String
            Get
                Return _Thrustersonline
            End Get
            Set(ByVal value As String)
                _Thrustersonline = value
            End Set
        End Property

        Public Property GeneratorsOnline() As String
            Get
                Return _GeneratorsOnline
            End Get
            Set(ByVal value As String)
                _GeneratorsOnline = value
            End Set
        End Property


        Public Property ToneMilesSinceLastCut() As String
            Get
                Return _ToneMilesSinceLastCut
            End Get
            Set(ByVal value As String)
                _ToneMilesSinceLastCut = value
            End Set
        End Property

        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property

        Public Property YestStock_Bentonite() As String
            Get
                Return _YestStock_Bentonite
            End Get
            Set(ByVal value As String)
                _YestStock_Bentonite = value
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

        Public Property Base_oil() As String
            Get
                Return _Base_oil
            End Get
            Set(ByVal value As String)
                _Base_oil = value
            End Set
        End Property
        Public Property Brine() As String
            Get
                Return _Brine
            End Get
            Set(ByVal value As String)
                _Brine = value
            End Set
        End Property
        Public Property Acetyl_Empty() As String
            Get
                Return _Acetyl_Empty
            End Get
            Set(ByVal value As String)
                _Acetyl_Empty = value
            End Set
        End Property
        Public Property Acetyl_InUse() As String
            Get
                Return _Acetyl_InUse
            End Get
            Set(ByVal value As String)
                _Acetyl_InUse = value
            End Set
        End Property
        Public Property Acetyl_FullBottles() As String
            Get
                Return _Acetyl_FullBottles
            End Get
            Set(ByVal value As String)
                _Acetyl_FullBottles = value
            End Set
        End Property
        Public Property Oxygen_Empty() As String
            Get
                Return _Oxygen_Empty
            End Get
            Set(ByVal value As String)
                _Oxygen_Empty = value
            End Set
        End Property
        Public Property Oxygen_InUse() As String
            Get
                Return _Oxygen_InUse
            End Get
            Set(ByVal value As String)
                _Oxygen_InUse = value
            End Set
        End Property
        Public Property Oxygen_FullBottles() As String
            Get
                Return _Oxygen_FullBottles
            End Get
            Set(ByVal value As String)
                _Oxygen_FullBottles = value
            End Set
        End Property
        Public Property Nitrogen_Empty() As String
            Get
                Return _Nitrogen_Empty
            End Get
            Set(ByVal value As String)
                _Nitrogen_Empty = value
            End Set
        End Property
        Public Property Nitrogen_InUse() As String
            Get
                Return _Nitrogen_InUse
            End Get
            Set(ByVal value As String)
                _Nitrogen_InUse = value
            End Set
        End Property
        Public Property Nitrogen_FullBottles() As String
            Get
                Return _Nitrogen_FullBottles
            End Get
            Set(ByVal value As String)
                _Nitrogen_FullBottles = value
            End Set
        End Property
        Public Property LubOil() As String
            Get
                Return _LubOil
            End Get
            Set(ByVal value As String)
                _LubOil = value
            End Set
        End Property
        Public Property Helifuel() As String
            Get
                Return _Helifuel
            End Get
            Set(ByVal value As String)
                _Helifuel = value
            End Set
        End Property
        Public Property RecivedMade_CmtBlended() As String
            Get
                Return _RecivedMade_CmtBlended
            End Get
            Set(ByVal value As String)
                _RecivedMade_CmtBlended = value
            End Set
        End Property
        Public Property RecivedMade_CementG() As String
            Get
                Return _RecivedMade_CementG
            End Get
            Set(ByVal value As String)
                _RecivedMade_CementG = value
            End Set
        End Property
        Public Property RecivedMade_Gel() As String
            Get
                Return _RecivedMade_Gel
            End Get
            Set(ByVal value As String)
                _RecivedMade_Gel = value
            End Set
        End Property
        Public Property RecivedMade_Bentoniote() As String
            Get
                Return _RecivedMade_Bentoniote
            End Get
            Set(ByVal value As String)
                _RecivedMade_Bentoniote = value
            End Set
        End Property
        Public Property RecivedMade_Barite() As String
            Get
                Return _RecivedMade_Barite
            End Get
            Set(ByVal value As String)
                _RecivedMade_Barite = value
            End Set
        End Property
        Public Property RecivedMade_LubOil() As String
            Get
                Return _RecivedMade_LubOil
            End Get
            Set(ByVal value As String)
                _RecivedMade_LubOil = value
            End Set
        End Property
        Public Property RecivedMade_DrillWater() As String
            Get
                Return _RecivedMade_DrillWater
            End Get
            Set(ByVal value As String)
                _RecivedMade_DrillWater = value
            End Set
        End Property
        Public Property RecivedMade_Diesel() As String
            Get
                Return _RecivedMade_Diesel
            End Get
            Set(ByVal value As String)
                _RecivedMade_Diesel = value
            End Set
        End Property
        Public Property RecivedMade_PotWater() As String
            Get
                Return _Used_CementG
            End Get
            Set(ByVal value As String)
                _Used_CementG = value
            End Set
        End Property

        Public Property Used_CmtBlended() As String
            Get
                Return _Used_CementG
            End Get
            Set(ByVal value As String)
                _Used_CementG = value
            End Set
        End Property
        Public Property Used_CementG() As String
            Get
                Return _Used_CementG
            End Get
            Set(ByVal value As String)
                _Used_CementG = value
            End Set
        End Property
        Public Property Used_Gel() As String
            Get
                Return _Used_Gel
            End Get
            Set(ByVal value As String)
                _Used_Gel = value
            End Set
        End Property

        Public Property Used_Bentoniote() As String
            Get
                Return _Used_Bentoniote
            End Get
            Set(ByVal value As String)
                _Used_Bentoniote = value
            End Set
        End Property
        Public Property Used_Barite() As String
            Get
                Return _Used_Barite
            End Get
            Set(ByVal value As String)
                _Used_Barite = value
            End Set
        End Property
        Public Property Used_LubOil() As String
            Get
                Return _Used_LubOil
            End Get
            Set(ByVal value As String)
                _Used_LubOil = value
            End Set
        End Property
        Public Property Used_DrillWater() As String
            Get
                Return _Used_DrillWater
            End Get
            Set(ByVal value As String)
                _Used_DrillWater = value
            End Set
        End Property

        Public Property Used_Diesel() As String
            Get
                Return _Used_PotWater
            End Get
            Set(ByVal value As String)
                _Used_PotWater = value
            End Set
        End Property

        Public Property Used_PotWater() As String
            Get
                Return _Used_PotWater
            End Get
            Set(ByVal value As String)
                _Used_PotWater = value
            End Set
        End Property

        Public Property TodayStock_CMTBlended() As String
            Get
                Return _TodayStock_CMTBlended
            End Get
            Set(ByVal value As String)
                _TodayStock_CMTBlended = value
            End Set
        End Property
        Public Property TodayStock_CementG() As String
            Get
                Return _TodayStock_CementG
            End Get
            Set(ByVal value As String)
                _TodayStock_CementG = value
            End Set
        End Property
        Public Property TodayStock_Gel() As String
            Get
                Return _TodayStock_Gel
            End Get
            Set(ByVal value As String)
                _TodayStock_Gel = value
            End Set
        End Property
        Public Property TodayStock_Bentonite() As String
            Get
                Return _TodayStock_Bentonite
            End Get
            Set(ByVal value As String)
                _TodayStock_Bentonite = value
            End Set
        End Property
        Public Property TodayStock_Barite() As String
            Get
                Return _TodayStock_Barite
            End Get
            Set(ByVal value As String)
                _TodayStock_Barite = value
            End Set
        End Property
        Public Property TodayStock_LubOil() As String
            Get
                Return _TodayStock_LubOil
            End Get
            Set(ByVal value As String)
                _TodayStock_LubOil = value
            End Set
        End Property
        Public Property TodayStock_DrillWater() As String
            Get
                Return _TodayStock_DrillWater
            End Get
            Set(ByVal value As String)
                _TodayStock_DrillWater = value
            End Set
        End Property
        Public Property TodayStock_Diesel() As String
            Get
                Return _TodayStock_Diesel
            End Get
            Set(ByVal value As String)
                _TodayStock_Diesel = value
            End Set
        End Property
        Public Property TodayStock_PotWater() As String
            Get
                Return _TodayStock_PotWater
            End Get
            Set(ByVal value As String)
                _TodayStock_PotWater = value
            End Set
        End Property
        Public Property YestStock_CmtBlended() As String
            Get
                Return _YestStock_CmtBlended
            End Get
            Set(ByVal value As String)
                _YestStock_CmtBlended = value
            End Set
        End Property
        Public Property YestStock_CementG() As String
            Get
                Return _YestStock_CementG
            End Get
            Set(ByVal value As String)
                _YestStock_CementG = value
            End Set
        End Property
        Public Property YestStock_Gel() As String
            Get
                Return _YestStock_Gel
            End Get
            Set(ByVal value As String)
                _YestStock_Gel = value
            End Set
        End Property
        Public Property YestStock_Barite() As String
            Get
                Return _YestStock_Barite
            End Get
            Set(ByVal value As String)
                _YestStock_Barite = value
            End Set
        End Property

        Public Property YestStock_LubOil() As String
            Get
                Return _YestStock_LubOil
            End Get
            Set(ByVal value As String)
                _YestStock_LubOil = value
            End Set
        End Property
        Public Property YestStock_DrillWater() As String
            Get
                Return _YestStock_DrillWater
            End Get
            Set(ByVal value As String)
                _YestStock_DrillWater = value
            End Set
        End Property
        Public Property YestStock_Diesel() As String
            Get
                Return _YestStock_Diesel
            End Get
            Set(ByVal value As String)
                _YestStock_Diesel = value
            End Set
        End Property
        Public Property YestStock_PotWater() As String
            Get
                Return _YestStock_PotWater
            End Get
            Set(ByVal value As String)
                _YestStock_PotWater = value
            End Set
        End Property
        Public Property COMTest() As String
            Get
                Return _COMTest
            End Get
            Set(ByVal value As String)
                _COMTest = value
            End Set
        End Property
        Public Property BOPTest() As String
            Get
                Return _BOPTest
            End Get
            Set(ByVal value As String)
                _BOPTest = value
            End Set
        End Property
        Public Property FireDrill() As Date
            Get
                Return _FireDrill
            End Get
            Set(ByVal value As Date)
                _FireDrill = value
            End Set
        End Property
        Public Property LastboatDrill() As Date
            Get
                Return _LastboatDrill
            End Get
            Set(ByVal value As Date)
                _LastboatDrill = value
            End Set
        End Property
        Public Property RemainingPayload() As String
            Get
                Return _RemainingPayload
            End Get
            Set(ByVal value As String)
                _RemainingPayload = value
            End Set
        End Property
        Public Property UsedPlayload() As String
            Get
                Return _UsedPlayload
            End Get
            Set(ByVal value As String)
                _UsedPlayload = value
            End Set
        End Property

        Public Property AirGap() As String
            Get
                Return _AirGap
            End Get
            Set(ByVal value As String)
                _AirGap = value
            End Set
        End Property
        Public Property Marine_ID() As Integer
            Get
                Return _Marine_ID
            End Get
            Set(ByVal value As Integer)
                _Marine_ID = value
            End Set
        End Property


    End Class
End Namespace
