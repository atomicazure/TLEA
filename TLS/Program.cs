using TensorLatticeEncryption;
using System;

// Top-level statements
Console.WriteLine("Enter the tensor dimensions (e.g., '30'):");
int dimension = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the noise level (standard deviation):");
double noiseLevel = double.Parse(Console.ReadLine());

Console.WriteLine("Enter the plain text to encrypt:");
string plainText = Console.ReadLine();

// Generate original tensor from plain text
float[] inputTensor = TensorHelper.TextToTensor(plainText, dimension);

Console.WriteLine("Original Tensor:");
TensorHelper.PrintTensor(inputTensor);

Random rand = new Random();

// Generate public and private tensors
float[] publicTensor = TensorHelper.GenerateRandomTensor(dimension, rand);
float[] privateTensor = TensorHelper.GenerateRandomTensor(dimension, rand);

// Generate noise tensor
float[] noiseTensor = TensorHelper.GenerateNoiseTensor(dimension, noiseLevel, rand);

// Encrypt the tensor
float[] encryptedTensor = EncryptionAlgorithm.EncryptTensor(inputTensor, publicTensor, privateTensor, noiseTensor);

Console.WriteLine("\nEncrypting...");
Console.WriteLine("Encrypted Tensor:");
TensorHelper.PrintTensor(encryptedTensor);

// Decrypt the tensor
float[] decryptedTensor = EncryptionAlgorithm.DecryptTensor(encryptedTensor, publicTensor, privateTensor, noiseTensor);

Console.WriteLine("\nDecrypting...");
Console.WriteLine("Decrypted Tensor:");
TensorHelper.PrintTensor(decryptedTensor);

// Convert decrypted tensor back to text
string decryptedText = TensorHelper.TensorToText(decryptedTensor);
Console.WriteLine("Decrypted Text: " + decryptedText);
