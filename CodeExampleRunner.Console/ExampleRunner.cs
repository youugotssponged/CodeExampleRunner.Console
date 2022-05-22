using log4net;
using System.Reflection;

namespace CodeExampleRunner.Console
{
    public interface IExample
    {
        public bool Skip { get; set; }
        public void RunExample();
    }

    public class ExampleRunner
    {
        public static readonly string DefaultMessage = "This is purely a code example, please refer to source for this module";
        private readonly ILog log;

        public ExampleRunner()
        {
            log4net.Config.BasicConfigurator.Configure();
            log = LogManager.GetLogger(typeof(ExampleRunner));
        }

        public void ScanAndRunExamplesInCurrentAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IExample).IsAssignableFrom(x));

            foreach (var example in types)
            {
                if (example.Name == "IExample") continue;

                dynamic instance = Activator.CreateInstance(example) ?? new object();

                var prop = instance.GetType().GetProperty("Skip");

                bool skipExample = true;
                if (prop != null && prop?.PropertyType == typeof(bool))
                    skipExample = Convert.ChangeType(prop?.GetValue(instance, null), prop?.PropertyType);

                if (skipExample) continue;

                log.Info($"[EXAMPLE] CLASS SCANNED {example.Name}");
                instance.GetType()?.GetMethod("RunExample")?.Invoke(instance, null);
            }
        }
    }
}