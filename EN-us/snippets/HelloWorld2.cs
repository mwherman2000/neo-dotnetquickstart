public class HelloWorld : SmartContract
{
    public static int Main(int value)
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");

	return value * 10;
    }
}