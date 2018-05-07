namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);

            var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);

            var instance = constructor.Invoke(new object[] {});

            var field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            while (true)
            {
                string[] commands = Console.ReadLine().Split('_');
                if (commands[0] == "END")
                {
                    break;
                }
                string command = commands[0];
                int value = int.Parse(commands[1]);

                InvokePrivateMethod(type, instance, command, value);

                Console.WriteLine(field.GetValue(instance));
            }
        }

        private static void InvokePrivateMethod(Type type, object instance, string command, int value)
        {
            var method = type.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(instance, new object[] { value });
        }
    }
}
