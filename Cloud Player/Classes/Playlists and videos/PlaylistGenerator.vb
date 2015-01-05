Imports System.Xml
Imports System.IO
Imports System.Reflection

Public Class PlaylistGenerator

#Region "Generator"

    Public Shared ReadOnly GeneratorVersion As String = "1.0.0.3"

    Public Shared Function GenerateXml(Playlist As Playlist) As XmlDocument
        With Playlist

            Dim videolocation As New Dictionary(Of Integer, String)
            Dim videoservice As New Dictionary(Of Integer, String)
            Dim videotitle As New Dictionary(Of Integer, String)
            Dim videocreator As New Dictionary(Of Integer, String)
            Dim videolength As New Dictionary(Of Integer, TimeSpan)
            Dim videothumbnail As New Dictionary(Of Integer, String)

            Dim i As Integer = 0
            For Each vid In .Videos
                videolocation.Add(i, vid.Location)
                videoservice.Add(i, vid.Service)
                videotitle.Add(i, vid.Title)
                videocreator.Add(i, vid.Creator)
                videolength.Add(i, vid.Length)
                videothumbnail.Add(i, vid.Thumbnail)
                i += 1
            Next

            Return (GenerateXml(.Title, .ID, .Thumbnail, videolocation, videoservice, videotitle, videocreator, videolength, videothumbnail))

        End With
    End Function

    Private Shared Function GenerateXml(Title As String, ID As Guid, Thumbnail As String, VideoLocations As Dictionary(Of Integer, String), videoservice As Dictionary(Of Integer, String), videotitle As Dictionary(Of Integer, String), videocreator As Dictionary(Of Integer, String), videolength As Dictionary(Of Integer, TimeSpan), videothumbnail As Dictionary(Of Integer, String)) As XmlDocument

        Dim xml As New XmlDocument

        'Create root node
        Dim rootnode As XmlNode = xml.AppendChild(xml.CreateElement("Playlist"))

        'Add the generator version attribute
        Dim at As XmlAttribute = xml.CreateAttribute("PlaylistGeneratorVersion")
        at.InnerText = GeneratorVersion
        rootnode.Attributes.Append(at)

        Dim titlenode As XmlNode = rootnode.AppendChild(xml.CreateElement("Title"))
        Dim guidnode As XmlNode = rootnode.AppendChild(xml.CreateElement("GUID"))
        Dim thumbnailnode As XmlNode = rootnode.AppendChild(xml.CreateElement("Thumbnail"))

        titlenode.InnerText = Title
        guidnode.InnerText = ID.ToString
        thumbnailnode.InnerText = Thumbnail

        Dim videosnode As XmlNode = rootnode.AppendChild(xml.CreateElement("Videos"))

        For i As Integer = 0 To VideoLocations.Count - 1

            Dim node As XmlNode = videosnode.AppendChild(xml.CreateElement("Video"))

            Dim locationnode As XmlNode = node.AppendChild(xml.CreateElement("Location"))
            Dim servicenode As XmlNode = node.AppendChild(xml.CreateElement("Service"))
            Dim vtitlenode As XmlNode = node.AppendChild(xml.CreateElement("Title"))
            Dim creatornode As XmlNode = node.AppendChild(xml.CreateElement("Creator"))
            Dim lengthnode As XmlNode = node.AppendChild(xml.CreateElement("Length"))
            Dim vthumbnailnode As XmlNode = node.AppendChild(xml.CreateElement("Thumbnail"))

            locationnode.InnerText = VideoLocations(i).ToString
            servicenode.InnerText = videoservice(i)
            vtitlenode.InnerText = videotitle(i)
            creatornode.InnerText = videocreator(i)
            lengthnode.InnerText = videolength(i).ToString
            vthumbnailnode.InnerText = videothumbnail(i)

        Next

        Return xml

    End Function

    Private Shared Function ParseXml(XmlDocument As XmlDocument, File As FileInfo) As Playlist

        Dim ver As String = GetGeneratorVersionOfPlaylist(XmlDocument)

        Try

            'Check if the generator version is supported
            If CheckGeneratorVersion(XmlDocument) = False Then
                Throw New ParseException("Playlist was generated with a different version than the current.", File, GeneratorVersion, ver, New NotImplementedException)
            End If

            Dim title As String = DecodeXML(XmlDocument("Playlist")("Title").InnerText)
            Dim id As Guid = Guid.Parse(XmlDocument("Playlist")("GUID").InnerText)
            Dim thumbnail As String = DecodeXML(XmlDocument("Playlist")("Thumbnail").InnerText)

            Dim videos As New List(Of Video)

            For Each node As XmlNode In XmlDocument("Playlist")("Videos")

                Dim Service As String = DecodeXML(node("Service").InnerText)
                Dim location As String = node("Location").InnerText
                Dim vTitle As String = node("Title").InnerText
                Dim Creator As String = DecodeXML(node("Creator").InnerText)
                Dim Length As TimeSpan = TimeSpan.Parse(node("Length").InnerText)
                Dim vThumbnail As String = DecodeXML(node("Thumbnail").InnerText)

                videos.Add(New Video(location, Service, vTitle, Creator, Length, vThumbnail))

            Next

            Return New Playlist(id, title, thumbnail, videos.ToArray)

        Catch e As NullReferenceException
            'The xml is probably not a valid playlist file
            Log.Write("PlaylistManager", e.Message)
            Throw New ParseException("The file was not of a valid playlist format.", File, GeneratorVersion, ver, e)
        Catch ex As XmlException
            'The xml file could not be parsed
            Log.Write("PlaylistManager", ex.Message)
            Throw New ParseException("The file was not of a valid playlist format.", File, GeneratorVersion, ver, ex)
        Catch ex1 As NotSupportedException
            'The file was created with a other version of the generator than the current one.
            Log.Write("PlaylistManager", ex1.Message)
            Throw New ParseException("The file was created with a different generator version than the current one.", File, GeneratorVersion, ver, ex1)
        End Try

    End Function

    Private Shared Function DecodeXML(ByVal s As String) As String
        If Len(s) = 0 Then Return ""
        Dim decodedString As String = ""
        Dim readersettings = New System.Xml.XmlReaderSettings
        readersettings.ConformanceLevel = Xml.ConformanceLevel.Fragment
        Dim ms = New System.IO.StringReader(s)
        Using reader = System.Xml.XmlReader.Create(ms, readersettings)
            reader.MoveToContent()
            decodedString = reader.ReadString
        End Using
        Return decodedString
    End Function

#End Region
#Region "Functions"

    Public Shared Function Load(File As FileInfo, Optional ThrowOnError As Boolean = True, Optional ShowErrorDialogInternally As Boolean = True) As Playlist


        'Validate the file before continuing
        If ValidateFile(File, ThrowOnError, ShowErrorDialogInternally) = False Then
            Return Nothing
        End If

        Try

            'Load document
            Dim xml As New XmlDocument
            xml.Load(File.FullName)

            Return ParseXml(xml, File)

        Catch ex As ParseException
            'An error occured while parsing
            If ShowErrorDialogInternally Then
                ShowErrorDialog(ex, File, ThrowOnError, ShowErrorDialogInternally)
            End If
            If ThrowOnError Then
                Throw ex
            End If

        Catch ex1 As XmlException
            'Could not load file as xml
            If ShowErrorDialogInternally Then
                ShowErrorDialog(ex1, File, ThrowOnError, ShowErrorDialogInternally)
            End If
            If ThrowOnError Then
                Throw New ParseException("File was not of a proper playlist format.", File, GeneratorVersion, "Unknown", ex1)
            End If
        End Try

        Return Nothing

    End Function

    Public Shared Sub Save(Playlist As Playlist)

        With Playlist
            Dim xml As XmlDocument = GenerateXml(Playlist)
            xml.Save(PlaylistStore.GetFile(.ID.ToString + ".xml").FullName)
        End With

    End Sub

    Private Shared Function GetGeneratorVersionOfPlaylist(XmlDocument As XmlDocument) As String

        Dim fileversion As String = "Unknown"

        If XmlDocument("Playlist").GetAttribute("PlaylistGeneratorVersion") IsNot Nothing Then
            fileversion = XmlDocument("Playlist").GetAttribute("PlaylistGeneratorVersion")
        End If

        Return fileversion

    End Function

    Private Shared Function ValidateFile(File As FileInfo, ThrowOnError As Boolean, ShowErrorDialogInternally As Boolean) As Boolean

        If Not File.Exists Then
            If ShowErrorDialogInternally Then
                Dim d As New PlaylistLoadErrorDialog
                d.ShowDialog(File, GeneratorVersion, "Unknown", "File does not exist.", , False, False, False)
            End If
            If ThrowOnError Then
                Throw New FileNotFoundException
            Else
                Return False
            End If
        End If

        If Not File.Extension = ".xml" Then

            If ShowErrorDialogInternally Then

                Dim d As New PlaylistLoadErrorDialog

                Select Case d.ShowDialog( _
                    File, GeneratorVersion, "Unknown", "The file was not of a valid playlist format.", , True, True, False)

                    Case Is = PlaylistLoadErrorDialog.DialogResult.Ignore
                        Return False

                    Case Is = PlaylistLoadErrorDialog.DialogResult.Delete
                        File.MoveToRecycleBin()
                        Return False

                End Select

            End If

            If ThrowOnError Then
                Throw New ArgumentException
            Else
                Return False
            End If

        End If

        Return True

    End Function

    Private Shared Function CheckGeneratorVersion(Xml As XmlDocument) As Boolean
        If Xml("Playlist") IsNot Nothing Then
            Dim ver As String = Xml("Playlist").GetAttribute("PlaylistGeneratorVersion")
            Return (ver = GeneratorVersion)
        End If
        Return False
    End Function

    Private Shared Sub ShowErrorDialog(Exception As Exception, File As FileInfo, ThrowOnError As Boolean, ShowErrorDialogInternally As Boolean)

        Dim d As New PlaylistLoadErrorDialog

        If TypeOf Exception.InnerException Is NotImplementedException Then

            Select Case PlaylistDifferentVersionDialog.ShowDialog( _
                File.FullName, GeneratorVersion, CType(Exception, ParseException).PlaylistVersion)

                Case Is = PlaylistDifferentVersionDialog.DialogResult.Ignore

                Case Is = PlaylistDifferentVersionDialog.DialogResult.Delete
                    File.MoveToRecycleBin()

                Case Is = PlaylistDifferentVersionDialog.DialogResult.Upgrade
                    UpgradePlaylist(File.FullName)

            End Select

        ElseIf TypeOf Exception Is XmlException Then

            Select Case d.ShowDialog( _
                File, GeneratorVersion, "Unknown", Exception.Message)

                Case Is = PlaylistLoadErrorDialog.DialogResult.Ignore
                    'Do nothing

                Case Is = PlaylistLoadErrorDialog.DialogResult.Delete
                    File.MoveToRecycleBin()

                Case Is = PlaylistLoadErrorDialog.DialogResult.Retry
                    Load(File, ThrowOnError, ShowErrorDialogInternally)

            End Select

        Else

            Select Case d.ShowDialog( _
                File, GeneratorVersion, CType(Exception, ParseException).PlaylistVersion, Exception.Message + vbNewLine + vbNewLine + Exception.InnerException.Message)

                Case Is = PlaylistLoadErrorDialog.DialogResult.Ignore
                    'Do nothing

                Case Is = PlaylistLoadErrorDialog.DialogResult.Delete
                    File.MoveToRecycleBin()

                Case Is = PlaylistLoadErrorDialog.DialogResult.Retry
                    Load(File, ThrowOnError, ShowErrorDialogInternally)

            End Select

        End If
    End Sub

#End Region
#Region "ParseException"

    Public Class ParseException
        Inherits Exception

        Private _GeneratorVersion As String
        Public ReadOnly Property GeneratorVersion As String
            Get
                Return _GeneratorVersion
            End Get
        End Property

        Private _PlaylistVersion As String
        Public ReadOnly Property PlaylistVersion As String
            Get
                Return _PlaylistVersion
            End Get
        End Property

        Private _File As FileInfo
        Public ReadOnly Property File As FileInfo
            Get
                Return _File
            End Get
        End Property

        Sub New(Message As String, File As FileInfo, GeneratorVersion As String, PlaylistVersion As String, InnerException As Exception)
            MyBase.New(Message, InnerException)
            _File = File
            _GeneratorVersion = GeneratorVersion
            _PlaylistVersion = PlaylistVersion
        End Sub

    End Class

#End Region
#Region "Upgrade"

    Public Shared Sub UpgradePlaylist(File As String)

        Try

            Dim xml As New XmlDocument
            xml.Load(File)

            IO.File.Move(File, BackupDir.FullName + "\" + File.Split("\").Last)

            xml = UpgradePlaylist(xml)
            xml.Save(File)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Shared Function UpgradePlaylist(XmlDocument As XmlDocument) As XmlDocument

        'Declare properties of current version
        Dim title As String = ""
        Dim id As Guid = Nothing
        Dim thumbnail As String = ""

        Dim videolocation As New Dictionary(Of Integer, String)
        Dim videoservice As New Dictionary(Of Integer, String)
        Dim videotitle As New Dictionary(Of Integer, String)
        Dim videocreator As New Dictionary(Of Integer, String)
        Dim videolength As New Dictionary(Of Integer, TimeSpan)
        Dim videothumbnail As New Dictionary(Of Integer, String)

        Dim version As String = GetGeneratorVersionOfPlaylist(XmlDocument)

        'Get values
        Select Case version

            Case Is = "1.0.0.1a"

                title = GetTextFromNode(XmlDocument("Playlist")("Title"))
                Guid.TryParse(GetTextFromNode(XmlDocument("Playlist")("GUID")), id)
                thumbnail = GetTextFromNode(XmlDocument("Playlist")("Thumbnail"))

                Dim i As Integer = 0
                For Each Video As XmlNode In XmlDocument("Playlist")("Videos")
                    videolocation.Add(i, GetTextFromNode(Video("Link")))
                    videoservice.Add(i, GetTextFromNode(Video("ServiceProvider")))
                    videotitle.Add(i, GetTextFromNode(Video("Title")))
                    videocreator.Add(i, GetTextFromNode(Video("Uploader")))
                    videothumbnail.Add(i, GetTextFromNode(Video("Thumbnail")))

                    Dim ts As TimeSpan
                    If TimeSpan.TryParse(GetTextFromNode(Video("Length")), ts) = True Then
                        videolength.Add(i, ts)
                    Else
                        videolength.Add(i, Nothing)
                    End If

                    i += 1

                Next

        End Select

        'Generate new xmldocument using the values
        Dim Xml As XmlDocument = GenerateXml(title, id, thumbnail, videolocation, videoservice, videotitle, videocreator, videolength, videothumbnail)
        Return Xml

    End Function

    ''' <summary>Returns the text of an node, returns "" if node does not exist.</summary>
    Private Shared Function GetTextFromNode(XmlNode As XmlNode) As String
        Dim str As String = ""
        If XmlNode IsNot Nothing Then
            str = DecodeXML(XmlNode.InnerText)
        End If
        Return str
    End Function

#End Region

End Class
