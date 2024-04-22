namespace apis.Utils
{
    public class Variable
    {
//valid
        public static string PhoneInValid = "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters. Ex:0367977xxx";
        public static string EmailInValid = "Invalid Email.Please try again.Ex: xxx @xxx.xxx";
//data
        public static string PhoneNotExist = "Phone Not Existing in Database. Please register for an account using your phone number ";
        public static string PhoneExist = "Phone number already exists. Please try again with a different phone number.";
        public static string NoData = "No Data in Database.";
//OTP
        public static string OTPNotExpired = "The current OTP is still valid. Please Retry after 2 minutes.";
        public static string OTPExpired = "OTP Expired, Please choose to resend OTP.";
        public static string OTPInCorrect = "The OTP you entered is incorrect.";
        public static string SendOTPError = "Error from Server (The error may be due to OTP not being sent).";
//token
        public static string TokenError = "Generate invalid Token.";

//name model
        public static string Driver = "Driver";
        public static string Dispatcher = "Dispatcher";
        public static string Customer = "Customer";
        public static string Car = "Car";
        public static string DispathJob = "Dispath Job";

//Crud successfull
        public static string SendOTP(string? name)
        {
            return "Send OTP for "+name +" successful!!";
        }

        public static string Login(string? name)
        {
            return "Login for "+name +" successful!!";
        }


        //Crud successfull
        public static string Post(string name)
        {
            return "Create New "+name+" Successful!!";
        }
        public static string Put(string name)
        {
            return "Update " + name + " Successful!!";
        }
        public static string Delete(string name)
        {
            return "Delete " + name + " Successful!!";
        }
        public static string GetAll(string name)
        {
            return "Get All " + name + " Successful!!";
        }
        public static string GetOne(string name)
        {
            return "Get One " + name + " Successful!!";
        }

//Crud Fail
        public static string PostFail(string name)
        {
            return "Create New " + name + " Fail, Please try again!!";
        }
        public static string PutFail(string name)
        {
            return "Update " + name + " Fail, Please try again!!";
        }
        public static string DeleteFail(string name)
        {
            return "Delete " + name + " Fail, Please try again!!";
        }
        public static string GetAllFail(string name)
        {
            return "Get All " + name + " Fail, Please try again!!";
        }
        public static string GetOneFail(string name)
        {
            return "Get One " + name + " Fail, Please try again!!";
        }

     
    }
}
