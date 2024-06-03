namespace TensorLatticeEncryption
{
    public static class EncryptionAlgorithm
    {
        // Function to encrypt the tensor using the Tensor-Lattice Encryption Algorithm (TLEA)
        public static float[] EncryptTensor(float[] inputTensor, float[] publicTensor, float[] privateTensor, float[] noiseTensor)
        {
            int length = inputTensor.Length;
            float[] encryptedTensor = new float[length];
            for (int i = 0; i < length; i++)
            {
                encryptedTensor[i] = (inputTensor[i] + noiseTensor[i]) * privateTensor[i] + publicTensor[i];
            }
            return encryptedTensor;
        }

        // Function to decrypt the tensor
        public static float[] DecryptTensor(float[] encryptedTensor, float[] publicTensor, float[] privateTensor, float[] noiseTensor)
        {
            int length = encryptedTensor.Length;
            float[] decryptedTensor = new float[length];
            for (int i = 0; i < length; i++)
            {
                decryptedTensor[i] = (encryptedTensor[i] - publicTensor[i]) / privateTensor[i] - noiseTensor[i];
            }
            return decryptedTensor;
        }
    }
}
