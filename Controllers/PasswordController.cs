using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace myAPI.Controllers
{
    [Route("GeneratePassword")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        public class pswd
        {
            public string value { get; set; }
        }
        [HttpGet("password")]
        public pswd generatePassword(int l)
        {
          
        var p = new pswd();
            string pwd = "";
            int pwd_length = 0;
            Random rdm = new Random();
            string ascii_letters_upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string ascii_letters_lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string punctuation = @"!#$%&\()*+,-./:;<=>?@[\\]^_{|}~";
            string numbers = "0123456789";
            if (l == 1)
            {
                pwd_length = rdm.Next(5, 7);
                for (int i = 0; i < pwd_length - 1; i++)
                {
                    int n = rdm.Next(1, 3);
                    if (n == 1)
                    {
                        pwd += ascii_letters_upperCase[rdm.Next(0, 26)];
                    }
                    else if (n == 2)
                    {
                        pwd += ascii_letters_lowerCase[rdm.Next(0, 26)];
                        pwd += numbers[rdm.Next(0, 9)];
                    }
                }
                pwd += punctuation[rdm.Next(0, 31)];
                p.value = pwd;
                return p;
            }
            else if (l == 2)
            {
                pwd_length = rdm.Next(9, 14);
                for (int i = 0; i < pwd_length - 1; i++)
                {
                    int n = rdm.Next(1, 4);
                    if (n == 1)
                    {
                        pwd += ascii_letters_upperCase[rdm.Next(0, 26)];
                        pwd += numbers[rdm.Next(0, 9)];
                    }
                    else if (n == 2)
                    {
                        pwd += ascii_letters_lowerCase[rdm.Next(0, 26)];
                        pwd += punctuation[rdm.Next(0, 30)];
                    }
                    else
                    {
                        pwd += punctuation[rdm.Next(0, 30)];
                    }
                }
                pwd += numbers[rdm.Next(0, 9)];
                p.value = pwd;
                return p;
            }
            else
            {
                pwd_length = rdm.Next(11, 14);
                for (int i = 0; i < pwd_length - 1; i++)
                {
                    int n = rdm.Next(1, 3);
                    if (n == 1)
                    {
                        pwd += ascii_letters_upperCase[rdm.Next(0, 26)];
                        pwd += numbers[rdm.Next(0, 9)];
                        pwd += punctuation[rdm.Next(0, 31)];
                    }
                    else if (n == 2)
                    {
                        pwd += ascii_letters_lowerCase[rdm.Next(0, 26)];
                        pwd += numbers[rdm.Next(0, 9)];
                        pwd += punctuation[rdm.Next(0, 30)];
                    }
                }
                p.value = pwd;
                return p;
            }
        }
        [HttpGet("lowpassword")]
        public pswd getLowPwd()
        {
            var p = new pswd();
            string pwd = "";
            int pwd_length = 0;
            Random rdm = new Random();
            string ascii_letters_upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string ascii_letters_lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string punctuation = @"!#$%&\()*+,-./:;<=>?@[\\]^_{|}~";
            string numbers = "0123456789";
            pwd_length = rdm.Next(5, 7);
            for (int i = 0; i < pwd_length - 1; i++)
            {
                int n = rdm.Next(1, 3);
                if (n == 1)
                {
                    pwd += ascii_letters_upperCase[rdm.Next(0, 26)];
                }
                else if (n == 2)
                {
                    pwd += ascii_letters_lowerCase[rdm.Next(0, 26)];
                    pwd += numbers[rdm.Next(0, 9)];
                }
            }
            pwd += punctuation[rdm.Next(0, 31)];
            p.value = pwd;
            return p;
        }
    }
}
