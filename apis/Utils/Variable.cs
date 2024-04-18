namespace apis.Utils
{
    public class Variable
    {
//valid
        public string InValidPhone = "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters. Ex:0367977xxx";
        public string InValidEmail = "Invalid Email.Please try again.Ex: xxx @xxx.xxx";
//data
        public string PhoneNotExist = "Phone Not Existing in Database. Please register for an account using your phone number ";
        public string PhoneExist = "Phone number already exists. Please try again with a different phone number.";
        public string NoData = "No Data in Database.";
//OTP
        public string OTPNotExpired = "The current OTP is still valid. Please Retry after 2 minutes.";
        public string OTPExpired = "OTP Expired, Please choose to resend OTP.";
        public string OTPInCorrect = "The OTP you entered is incorrect.";
        public string SendOTPError = "Error from Server (The error may be due to OTP not being sent).";
//token
        public string TokenError = "Generate invalid Token.";

//name model
        public string Driver = "Driver";
        public string Dispatcher = "Dispatcher";
        public string Customer = "Customer";
        public string Car = "Car";
        public string DispathJob = "Dispath Job";

//Crud successfull
        public string SendOTP(string? name)
        {
            return "Send OTP successful!!";
        }

        public string Login(string? name)
        {
            return "Login successful!!";
        }


        //Crud successfull
        public string Post(string name)
        {
            return "Create New "+name+" Successful!!";
        }
        public string Put(string name)
        {
            return "Update " + name + " Successful!!";
        }
        public string Delete(string name)
        {
            return "Delete " + name + " Successful!!";
        }
        public string GetAll(string name)
        {
            return "Get All " + name + " Successful!!";
        }
        public string GetOne(string name)
        {
            return "Get One " + name + " Successful!!";
        }

//Crud Fail
        public string PostFail(string name)
        {
            return "Create New " + name + " Fail, Please try again!!";
        }
        public string PutFail(string name)
        {
            return "Update " + name + " Fail, Please try again!!";
        }
        public string DeleteFail(string name)
        {
            return "Delete " + name + " Fail, Please try again!!";
        }
        public string GetAllFail(string name)
        {
            return "Get All " + name + " Fail, Please try again!!";
        }
        public string GetOneFail(string name)
        {
            return "Get One " + name + " Fail, Please try again!!";
        }

     
    }
}
