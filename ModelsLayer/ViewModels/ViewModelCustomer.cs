namespace StoreApplication
{
    public class ViewModelCustomer
    {
        public int CustomerId { get; set; }
        private string _firstName;
        private string _lastName;
        public string CustPassword { get;set;}
 
        public string FirstName{
            get{
       return this._firstName;
        }set{
     if(value.Length>50 || value.Length==0){
                 this._firstName = "Invalid Input";
            }else{
                this._firstName = value;
            }
        }
        
        }

       public string LastName { 
           get{
                return this._lastName;
           } set{
    if(value.Length>50 || value.Length==0){
                 this._lastName = "Invalid Input";
            }else{
                this._lastName = value;
            }
           }
           
            }
       

        

 public ViewModelCustomer(string FirstName, string LastName){
    this.FirstName= FirstName;
    this.LastName = LastName;
}

public ViewModelCustomer(){
    
}

     

        
    }
}