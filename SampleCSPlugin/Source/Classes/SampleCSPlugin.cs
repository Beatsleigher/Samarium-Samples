using System;

namespace SampleCSPlugin {

    using Samarium.PluginFramework;
    using Samarium.PluginFramework.Command;
    using Samarium.PluginFramework.Config;
    using Samarium.PluginFramework.Plugin;

    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SampleCSPlugin : Plugin {


        public override string PluginName => nameof(SampleCSPlugin);

        private List<ICommand> _pluginCmds;
        public override List<ICommand> PluginCommands { get => _pluginCmds; }

        protected override IConfig PluginConfig => default;

        public override void OnLoaded() => Ok("Sample C# plugin has loaded! :)");
        public override bool OnStart() {
            Info("Loading plugin commands...");
            _pluginCmds = new List<ICommand> {
                new Command {
                    Arguments = new[] { "--csarg" },
                    CommandTag = "cscommand",
                    Description = 
                        "Sample command in a sample plugin written using C#.\n\n" +
                        "Usage:\n" +
                        "\tcscommand [--csarg]\n\n" +
                        "Description:\n" +
                        "\tArguments:\n" +
                        "\t\t--csarg\t\tPrints arbitrary data.",
                    Handler = (plugin, command, args) => { ToConsole("You executed a command in a sample plugin{0}!", args.Contains("--csarg") ? " with arguments" : ""); return null; },
                    ParentPlugin = this,
                    ShortDescription = "Sample command from a sample plugin."
                }
            };
            return true;
        }
        public override bool OnStop() => true;

    }
}
