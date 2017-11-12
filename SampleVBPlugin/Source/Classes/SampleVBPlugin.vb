Imports Samarium.PluginFramework
Imports Samarium.PluginFramework.Plugin
Imports Samarium.PluginFramework.Command
Imports Samarium.PluginFramework.Config

Public Class SampleVBPlugin
    Inherits Plugin

#Region "Variables"
    Private _pluginCommands As List(Of ICommand)
#End Region

    Public Overrides ReadOnly Property PluginName As String
        Get
            Return NameOf(SampleVBPlugin)
        End Get
    End Property

    Public Overrides ReadOnly Property PluginCommands As List(Of ICommand)
        Get
            Return _pluginCommands
        End Get
    End Property

    Protected Overrides ReadOnly Property PluginConfig As IConfig

    Public Overrides Sub OnLoaded()
        Info("I guess I've loaded successfully :)")
    End Sub

    Public Overrides Function OnStart() As Boolean

        Info("Loading plugin commands...")
        _pluginCommands = New List(Of ICommand) From {
            New Command() With {
                .Arguments = New String() {"--vbarg"},
                .CommandTag = "vbcmd",
                .Handler = Function(_plugin, _cmd, _args)
                               Info("You executed a command from {0}!", PluginName)
                               Return Nothing
                           End Function,
                .ParentPlugin = Me,
                .ShortDescription = "A short, simple description."
            }
        }

        Return True
    End Function

    Public Overrides Function OnStop() As Boolean
        Return True
    End Function
End Class
