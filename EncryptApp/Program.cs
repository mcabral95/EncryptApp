
var encryptMethods = new EncryptMethods.EncryptMethods();

Console.Write("Por favor inserte un string: ");
Console.Write("");
string text = Console.ReadLine();

Console.WriteLine("Encriptando...");

text = encryptMethods.EncryptText(text);

Console.WriteLine("Texto encriptado: " + text);

Console.WriteLine("Volviendo atras...");
text = encryptMethods.DecryptText(text);

Console.WriteLine("Texto desencriptado: " + text);