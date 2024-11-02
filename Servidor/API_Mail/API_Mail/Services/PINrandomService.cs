namespace API_Mail.Services
{
    public class PINrandomService
    {
        Random random = new Random();
        private static PINrandomService instance;

        private PINrandomService()
        {
            //
        }

        public static PINrandomService Instance()
        {
            if (instance == null)
            {
                instance = new PINrandomService();
            }

            return instance;
        }

        public string pinRandom()
        {
            string[] nums = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string pin = nums[random.Next(nums.Length)] +
             nums[random.Next(nums.Length)] +
             nums[random.Next(nums.Length)] +
             nums[random.Next(nums.Length)];

            Console.WriteLine(pin);

            return pin;
        }
    }
}
