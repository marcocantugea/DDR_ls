
Namespace com.entities

    Public Class DDRReport

        Private _DDR_Report_ID As Integer = -1
        Private _Operator_s As String
        Private _Contractor As String
        Private _Midnigth_Depth As String
        Private _TVD As String
        Private _Yesterdays_Depth As String
        Private _Progress As String
        Private _Formation As String
        Private _Mud_weight As String
        Private _Well As String
        Private _Block As String
        Private _Country As String
        Private _KSP_Hrs As String
        Private _Todays_Rot_Hrs As String
        Private _Yest_Rot_Hrs As String
        Private _Cum_Rot_Hrs As String
        Private _Leak_off_test As String
        Private _Tool_Pusher_Comments As String
        Private _Activities_Next24_hrs As String
        Private _TotalsHrs As String
        Private _Wind_Dir As String
        Private _Wind_Speed As String
        Private _Current_Dir As String
        Private _Temp_Air As String
        Private _Temp_Sea As String
        Private _Barometer As String
        Private _Sea As String
        Private _Swell As String
        Private _Roll As String
        Private _Pitch As String
        Private _Heave As String
        Private _Visibility As String
        Private _1_Comments As String
        Private _BITS_AnnVelCsg As String
        Private _BITS_AnnVel As String
        Private _BITS_DCVel As String
        Private _BITS_NozzleVel As String
        Private _DrillString_StringWeight As String
        Private _DrillString_Static As String
        Private _DrillString_WOB As String
        Private _DrillString_RPM As String
        Private _BHA_BelowJars As String
        Private _BHA_BAGWT As String
        Private _Mud_VolumeActivePits As String
        Private _Mud_HoleVolume As String
        Private _Mud_System As String
        Private _Mud_MaxGas As String
        Private _Mud_Comments As String
        Private _DaysFromSpud As String
        Private _ProposedTD As String
        Private _RKBToWH As String
        Private _RKBtoSeaBeadMtrs As String
        Private _TOLSize As String
        Private _LastCasing As String
        Private _WeightGR As String
        Private _CasingID As String
        Private _CsgShoeMtrs As String
        Private _DDRHrs As DDRHrs_Collection = Nothing
        Private _BITS As BITS_Collection = Nothing
        Private _DrillString As DrillString_Collection = Nothing
        Private _DrillString_survey As DrillString_Survey_Collection = Nothing
        Private _Pumps As Pumps_Collection = Nothing
        Private _Shakers As Shakers_Collection = Nothing
        Private _Mud As Mud_Collection = Nothing
        Private _MarineInfo As MarineInfo = Nothing
        Private _POB As POB = Nothing
        Private _DDRID As Integer = -1
        Private _DrillString_Torque As String
        Private _BHA_BottomHoleAssembly As String
        Private _BHA_Comments As String
        Private _Mud_Percent As String
        Private _Current_Speed As String
        Private _Activities As Activities_Collection = Nothing
        Private _RiserProfile As RiserProfileCollection = Nothing
        Private _PemexUnit As String
        Private _Washpipehrs As String
        Private _EstendWell As String
        Private _DDRDate As Date
        Private _UsedByPEP As String
        Private _DrillString_StackOffWeigth As String
        Private _DrillString_RotWeigth As String
        Private _DrillLineSlippedandCut As String
        Private _SOC As SOC = Nothing
        Private _LogisticTransitLog As LogisticTransitLogCollection
        Private _DrillString_PUWeight As String
        Private _UrgentsMR As New UrgentsMRsCollection
        Private _WorkOrders As New WorkOrderCollection
        Private _Tool_Pusher_Comments_Spanish As String
        Private _Activities_Next24_hrs_spanish As String
        Private _PumpsMeasureddepth As String
        Private _PumpsTrueverticaldepth As String
        Private _PumpsMudweigth As String
        Private _PUMR As PUMR_Collection
        Private _DrillString_ECD12 As String
        Private _DrillString_ECD24 As String


        Public Property DrillString_ECD24() As String
            Get
                Return _DrillString_ECD24
            End Get
            Set(ByVal value As String)
                _DrillString_ECD24 = value

            End Set
        End Property


        Public Property DrillString_ECD12() As String
            Get
                Return _DrillString_ECD12
            End Get
            Set(ByVal value As String)
                _DrillString_ECD12 = value

            End Set
        End Property


        Public Property PUMR() As PUMR_Collection
            Get
                Return _PUMR
            End Get
            Set(ByVal value As PUMR_Collection)
                _PUMR = value
            End Set
        End Property

        Public Property PumpsMudweigth() As String
            Get
                Return _PumpsMudweigth
            End Get
            Set(ByVal value As String)
                _PumpsMudweigth = value
            End Set
        End Property

        Public Property PumpsTrueverticaldepth() As String
            Get
                Return _PumpsTrueverticaldepth
            End Get
            Set(ByVal value As String)
                _PumpsTrueverticaldepth = value
            End Set
        End Property

        Public Property PumpsMeasureddepth() As String
            Get
                Return _PumpsMeasureddepth
            End Get
            Set(ByVal value As String)
                _PumpsMeasureddepth = value
            End Set
        End Property


        Public Property Tool_Pusher_Comments_Spanish() As String
            Get
                Return _Tool_Pusher_Comments_Spanish
            End Get
            Set(ByVal value As String)
                _Tool_Pusher_Comments_Spanish = value
            End Set
        End Property

        Public Property Activities_Next24_hrs_spanish() As String
            Get
                Return _Activities_Next24_hrs_spanish
            End Get
            Set(ByVal value As String)
                _Activities_Next24_hrs_spanish = value
            End Set
        End Property

        Public Property WorkOrders() As WorkOrderCollection
            Get
                Return _WorkOrders
            End Get
            Set(ByVal value As WorkOrderCollection)
                _WorkOrders = value
            End Set
        End Property

        Public Property UrgentsMR() As UrgentsMRsCollection
            Get
                Return _UrgentsMR
            End Get
            Set(ByVal value As UrgentsMRsCollection)
                _UrgentsMR = value
            End Set
        End Property

        Public Property DrillString_PUWeight() As String
            Get
                Return _DrillString_PUWeight
            End Get
            Set(ByVal value As String)
                _DrillString_PUWeight = value
            End Set
        End Property

        Public Property LogisticTransitLog() As LogisticTransitLogCollection
            Get
                Return _LogisticTransitLog
            End Get
            Set(ByVal value As LogisticTransitLogCollection)
                _LogisticTransitLog = value
            End Set
        End Property

        Public Property SOC() As SOC
            Get
                Return _SOC
            End Get
            Set(ByVal value As SOC)
                _SOC = value
            End Set
        End Property

        Public Property DrillLineSlippedandCut() As String
            Get
                Return _DrillLineSlippedandCut
            End Get
            Set(ByVal value As String)
                _DrillLineSlippedandCut = value
            End Set
        End Property

        Public Property DrillString_RotWeigth() As String
            Get
                Return _DrillString_RotWeigth
            End Get
            Set(ByVal value As String)
                _DrillString_RotWeigth = value
            End Set
        End Property

        Public Property DrillString_StackOffWeigth() As String
            Get
                Return _DrillString_StackOffWeigth
            End Get
            Set(ByVal value As String)
                _DrillString_StackOffWeigth = value
            End Set
        End Property

        Public Property UsedByPEP() As String
            Get
                Return _UsedByPEP
            End Get
            Set(ByVal value As String)
                _UsedByPEP = value
            End Set
        End Property

        Public Property DDRDate() As Date
            Get
                Return _DDRDate
            End Get
            Set(ByVal value As Date)
                _DDRDate = value
            End Set
        End Property

        Public Property EstendWell() As String
            Get
                Return _EstendWell
            End Get
            Set(ByVal value As String)
                _EstendWell = value
            End Set
        End Property

        Public Property Washpipehrs() As String
            Get
                Return _Washpipehrs
            End Get
            Set(ByVal value As String)
                _Washpipehrs = value
            End Set
        End Property

        Public Property PemexUnit() As String
            Get
                Return _PemexUnit
            End Get
            Set(ByVal value As String)
                _PemexUnit = value
            End Set
        End Property

        Public Property RiserProfile() As RiserProfileCollection
            Get
                Return _RiserProfile
            End Get
            Set(ByVal value As RiserProfileCollection)
                _RiserProfile = value
            End Set
        End Property

        Public Property Activities() As Activities_Collection
            Get
                Return _Activities
            End Get
            Set(ByVal value As Activities_Collection)
                _Activities = value
            End Set
        End Property

        Public Property DrillString_Survey() As DrillString_Survey_Collection
            Get
                Return _DrillString_survey
            End Get
            Set(ByVal value As DrillString_Survey_Collection)
                _DrillString_survey = value
            End Set
        End Property

        Public Property Current_Speed() As String
            Get
                Return _Current_Speed
            End Get
            Set(ByVal value As String)
                _Current_Speed = value
            End Set
        End Property

        Public Property Mud_Percent() As String
            Get
                Return _Mud_Percent
            End Get
            Set(ByVal value As String)
                _Mud_Percent = value
            End Set
        End Property

        Public Property BHA_Comments() As String
            Get
                Return _BHA_Comments
            End Get
            Set(ByVal value As String)
                _BHA_Comments = value
            End Set
        End Property

        Public Property BHA_BottomHoleAssembly() As String
            Get
                Return _BHA_BottomHoleAssembly
            End Get
            Set(ByVal value As String)
                _BHA_BottomHoleAssembly = value
            End Set
        End Property

        Public Property DrillString_Torque() As String
            Get
                Return _DrillString_Torque
            End Get
            Set(ByVal value As String)
                _DrillString_Torque = value
            End Set
        End Property

        Public Property DDRID() As Integer
            Get
                Return _DDRID
            End Get
            Set(ByVal value As Integer)
                _DDRID = value
            End Set
        End Property
        Public Property POB() As POB
            Get
                Return _POB
            End Get
            Set(ByVal value As POB)
                _POB = value
            End Set
        End Property

        Public Property MarineInfo() As MarineInfo
            Get
                Return _MarineInfo
            End Get
            Set(ByVal value As MarineInfo)
                _MarineInfo = value
            End Set
        End Property

        Public Property Mud() As Mud_Collection
            Get
                Return _Mud
            End Get
            Set(ByVal value As Mud_Collection)
                _Mud = value
            End Set
        End Property

        Public Property Shakers() As Shakers_Collection
            Get
                Return _Shakers
            End Get
            Set(ByVal value As Shakers_Collection)
                _Shakers = value
            End Set
        End Property

        Public Property Pumps() As Pumps_Collection
            Get
                Return _Pumps
            End Get
            Set(ByVal value As Pumps_Collection)
                _Pumps = value
            End Set
        End Property



        Public Property DrillString() As DrillString_Collection
            Get
                Return _DrillString
            End Get
            Set(ByVal value As DrillString_Collection)
                _DrillString = value
            End Set
        End Property

        Public Property BITS() As BITS_Collection
            Get
                Return _BITS
            End Get
            Set(ByVal value As BITS_Collection)
                _BITS = value
            End Set
        End Property

        Public Property DDRHrs() As DDRHrs_Collection
            Get
                Return _DDRHrs
            End Get
            Set(ByVal value As DDRHrs_Collection)
                _DDRHrs = value
            End Set
        End Property

        Public Property CsgShoeMtrs() As String
            Get
                Return _CsgShoeMtrs
            End Get
            Set(ByVal value As String)
                _CsgShoeMtrs = value
            End Set
        End Property
        Public Property CasingID() As String
            Get
                Return _CasingID
            End Get
            Set(ByVal value As String)
                _CasingID = value
            End Set
        End Property
        Public Property WeightGR() As String
            Get
                Return _WeightGR
            End Get
            Set(ByVal value As String)
                _WeightGR = value
            End Set
        End Property
        Public Property LastCasing() As String
            Get
                Return _LastCasing
            End Get
            Set(ByVal value As String)
                _LastCasing = value
            End Set
        End Property
        Public Property TOLSize() As String
            Get
                Return _TOLSize
            End Get
            Set(ByVal value As String)
                _TOLSize = value
            End Set
        End Property
        Public Property RKBtoSeaBeadMtrs() As String
            Get
                Return _RKBtoSeaBeadMtrs
            End Get
            Set(ByVal value As String)
                _RKBtoSeaBeadMtrs = value
            End Set
        End Property
        Public Property RKBToWH() As String
            Get
                Return _RKBToWH
            End Get
            Set(ByVal value As String)
                _RKBToWH = value
            End Set
        End Property
        Public Property ProposedTD() As String
            Get
                Return _ProposedTD
            End Get
            Set(ByVal value As String)
                _ProposedTD = value
            End Set
        End Property
        Public Property DaysFromSpud() As String
            Get
                Return _DaysFromSpud
            End Get
            Set(ByVal value As String)
                _DaysFromSpud = value
            End Set
        End Property
        Public Property Mud_Comments() As String
            Get
                Return _Mud_Comments
            End Get
            Set(ByVal value As String)
                _Mud_Comments = value
            End Set
        End Property
        Public Property Mud_MaxGas() As String
            Get
                Return _Mud_MaxGas
            End Get
            Set(ByVal value As String)
                _Mud_MaxGas = value
            End Set
        End Property
        Public Property Mud_System() As String
            Get
                Return _Mud_System
            End Get
            Set(ByVal value As String)
                _Mud_System = value
            End Set
        End Property
        Public Property Mud_HoleVolume() As String
            Get
                Return _Mud_HoleVolume
            End Get
            Set(ByVal value As String)
                _Mud_HoleVolume = value
            End Set
        End Property
        Public Property Mud_VolumeActivePits() As String
            Get
                Return _Mud_VolumeActivePits
            End Get
            Set(ByVal value As String)
                _Mud_VolumeActivePits = value
            End Set
        End Property
        Public Property BHA_BAGWT() As String
            Get
                Return _BHA_BAGWT
            End Get
            Set(ByVal value As String)
                _BHA_BAGWT = value
            End Set
        End Property
        Public Property BHA_BelowJars() As String
            Get
                Return _BHA_BelowJars
            End Get
            Set(ByVal value As String)
                _BHA_BelowJars = value
            End Set
        End Property
        Public Property DrillString_RPM() As String
            Get
                Return _DrillString_RPM
            End Get
            Set(ByVal value As String)
                _DrillString_RPM = value
            End Set
        End Property
        Public Property DrillString_WOB() As String
            Get
                Return _DrillString_WOB
            End Get
            Set(ByVal value As String)
                _DrillString_WOB = value
            End Set
        End Property
        Public Property DrillString_Static() As String
            Get
                Return _DrillString_Static
            End Get
            Set(ByVal value As String)
                _DrillString_Static = value
            End Set
        End Property
        Public Property DrillString_StringWeight() As String
            Get
                Return _DrillString_StringWeight
            End Get
            Set(ByVal value As String)
                _DrillString_StringWeight = value
            End Set
        End Property
        Public Property BITS_NozzleVel() As String
            Get
                Return _BITS_NozzleVel
            End Get
            Set(ByVal value As String)
                _BITS_NozzleVel = value
            End Set
        End Property
        Public Property BITS_DCVel() As String
            Get
                Return _BITS_DCVel
            End Get
            Set(ByVal value As String)
                _BITS_DCVel = value
            End Set
        End Property
        Public Property BITS_AnnVel() As String
            Get
                Return _BITS_AnnVel
            End Get
            Set(ByVal value As String)
                _BITS_AnnVel = value
            End Set
        End Property
        Public Property BITS_AnnVelCsg() As String
            Get
                Return _BITS_AnnVelCsg
            End Get
            Set(ByVal value As String)
                _BITS_AnnVelCsg = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Return _1_Comments
            End Get
            Set(ByVal value As String)
                _1_Comments = value
            End Set
        End Property
        Public Property Visibilty() As String
            Get
                Return _Visibility
            End Get
            Set(ByVal value As String)
                _Visibility = value
            End Set
        End Property
        Public Property Heave() As String
            Get
                Return _Heave
            End Get
            Set(ByVal value As String)
                _Heave = value
            End Set
        End Property
        Public Property Pitch() As String
            Get
                Return _Pitch
            End Get
            Set(ByVal value As String)
                _Pitch = value
            End Set
        End Property
        Public Property Roll() As String
            Get
                Return _Roll
            End Get
            Set(ByVal value As String)
                _Roll = value
            End Set
        End Property
        Public Property Swell() As String
            Get
                Return _Swell
            End Get
            Set(ByVal value As String)
                _Swell = value
            End Set
        End Property
        Public Property Sea() As String
            Get
                Return _Sea
            End Get
            Set(ByVal value As String)
                _Sea = value
            End Set
        End Property
        Public Property Barometer() As String
            Get
                Return _Barometer
            End Get
            Set(ByVal value As String)
                _Barometer = value
            End Set
        End Property
        Public Property Temp_Sea() As String
            Get
                Return _Temp_Sea
            End Get
            Set(ByVal value As String)
                _Temp_Sea = value
            End Set
        End Property
        Public Property Temp_Air() As String
            Get
                Return _Temp_Air
            End Get
            Set(ByVal value As String)
                _Temp_Air = value
            End Set
        End Property
        Public Property Current_Dir() As String
            Get
                Return _Current_Dir
            End Get
            Set(ByVal value As String)
                _Current_Dir = value
            End Set
        End Property
        Public Property Wind_Speed() As String
            Get
                Return _Wind_Speed
            End Get
            Set(ByVal value As String)
                _Wind_Speed = value
            End Set
        End Property
        Public Property Wind_Dir() As String
            Get
                Return _Wind_Dir
            End Get
            Set(ByVal value As String)
                _Wind_Dir = value
            End Set
        End Property
        Public Property TotalsHrs() As String
            Get
                Return _TotalsHrs
            End Get
            Set(ByVal value As String)
                _TotalsHrs = value
            End Set
        End Property
        Public Property Activities_Next24_hrs() As String
            Get
                Return _Activities_Next24_hrs
            End Get
            Set(ByVal value As String)
                _Activities_Next24_hrs = value
            End Set
        End Property
        Public Property Tool_Pusher_Comments() As String
            Get
                Return _Tool_Pusher_Comments
            End Get
            Set(ByVal value As String)
                _Tool_Pusher_Comments = value
            End Set
        End Property
        Public Property Leak_off_test() As String
            Get
                Return _Leak_off_test
            End Get
            Set(ByVal value As String)
                _Leak_off_test = value
            End Set
        End Property
        Public Property Cum_Rot_Hrs() As String
            Get
                Return _Cum_Rot_Hrs
            End Get
            Set(ByVal value As String)
                _Cum_Rot_Hrs = value
            End Set
        End Property
        Public Property Yest_Rot_Hrs() As String
            Get
                Return _Yest_Rot_Hrs
            End Get
            Set(ByVal value As String)
                _Yest_Rot_Hrs = value
            End Set
        End Property
        Public Property Todays_Rot_Hrs() As String
            Get
                Return _Todays_Rot_Hrs
            End Get
            Set(ByVal value As String)
                _Todays_Rot_Hrs = value
            End Set
        End Property
        Public Property KSP_Hrs() As String
            Get
                Return _KSP_Hrs
            End Get
            Set(ByVal value As String)
                _KSP_Hrs = value
            End Set
        End Property
        Public Property Country() As String
            Get
                Return _Country
            End Get
            Set(ByVal value As String)
                _Country = value
            End Set
        End Property
        Public Property Block() As String
            Get
                Return _Block
            End Get
            Set(ByVal value As String)
                _Block = value
            End Set
        End Property
        Public Property Well() As String
            Get
                Return _Well
            End Get
            Set(ByVal value As String)
                _Well = value
            End Set
        End Property
        Public Property Mud_weight() As String
            Get
                Return _Mud_weight
            End Get
            Set(ByVal value As String)
                _Mud_weight = value
            End Set
        End Property

        Public Property Formation() As String
            Get
                Return _Formation
            End Get
            Set(ByVal value As String)
                _Formation = value
            End Set
        End Property

        Public Property Progress() As String
            Get
                Return _Progress
            End Get
            Set(ByVal value As String)
                _Progress = value
            End Set
        End Property

        Public Property Yesterdays_Depth() As String
            Get
                Return _Yesterdays_Depth
            End Get
            Set(ByVal value As String)
                _Yesterdays_Depth = value
            End Set
        End Property

        Public Property TVD() As String
            Get
                Return _TVD
            End Get
            Set(ByVal value As String)
                _TVD = value
            End Set
        End Property

        Public Property Midnigth_Depth() As String
            Get
                Return _Midnigth_Depth
            End Get
            Set(ByVal value As String)
                _Midnigth_Depth = value
            End Set
        End Property

        Public Property Contractor() As String
            Get
                Return _Contractor
            End Get
            Set(ByVal value As String)
                _Contractor = value
            End Set
        End Property

        Public Property Operator_s() As String
            Get
                Return _Operator_s
            End Get
            Set(ByVal value As String)
                _Operator_s = value
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


    End Class
End Namespace
