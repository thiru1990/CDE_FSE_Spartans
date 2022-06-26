import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators,FormBuilder, AbstractControl} from '@angular/forms';
import { UpdatBid } from '../Model/updateBid';
import { BuyerService } from '../Shared/Service/Buyer/buyer.service';
import { NotificationService } from '../Shared/Service/notification.service'
   
@Component({
  selector: 'app-buyer',
  templateUrl: './buyer.component.html',
  styleUrls: ['./buyer.component.css'],
})
export class BuyerComponent implements OnInit {
  Myform : FormGroup;
  submitted = false;
  cities: string[];
  states: string[];
  dialogdisplay:boolean=false;
  dialogdisplaydelete:boolean=false;
  productid:number=0;
  productPrice:number=0;
  Email:string='';
  productiddelete:number=0;
  Emaildelete:string='';
  UpdateBidDetails1 :UpdatBid;
  constructor(private formBuilder:FormBuilder,private buyerService:BuyerService,
    private notifyService : NotificationService) { 
      this.UpdateBidDetails1=new UpdatBid();
    }

  ngOnInit(): void {
    this.initialiseForm();
    this.cities = this.getAllCities();
    this.states=this.getAllStates();
  }
  initialiseForm(){
  this.Myform=this.formBuilder.group({
    FirstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    LastName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    Address: new FormControl('', Validators.required),
    City:new FormControl ('',Validators.required),
    State:new FormControl ('',Validators.required),
    Pin: new FormControl('', Validators.required),
    Phone: new FormControl('', [Validators.required,Validators.maxLength(12)]),
    Email: new FormControl('', [Validators.required,Validators.email]),
    ProductId:new FormControl('',[Validators.required,Validators.required]),
    BidAmount:new FormControl('',[Validators.required,Validators.required])
  });}
  
  get f(): { [key: string]: AbstractControl } {
    return this.Myform.controls;
  }
   
  submit(): void {
    this.submitted = true;

    if (this.Myform.invalid) {
      console.log('Failedvalidation',"failedvalidation");
    }
    if(this.Myform.valid){
this.buyerService.placeBidDetails({
  FirstName:this.Myform.get('FirstName')?.value,
  LastName:this.Myform.get('LastName')?.value,
  Address:this.Myform.get('Address')?.value,
  City:this.Myform.get('City')?.value,
  State:this.Myform.get('State')?.value,
  Pin:this.Myform.get('Pin')?.value,
  Phone:this.Myform.get('Phone')?.value,
  Email:this.Myform.get('Email')?.value,
  ProductId:this.Myform.get('ProductId')?.value,
  BidAmount:this.Myform.get('BidAmount')?.value
}).subscribe(
  data => {console.log('result',data);
this.showSuccess();
});
    console.log(JSON.stringify(this.Myform.value, null, 2));
  }}

  showSuccess() {
    this.notifyService.showSuccess("Bid Placed successfully !!", "");
    this.ResetForm();
  
  }
  showUpdateSuccess() {
    this.notifyService.showSuccess("Bid Updated successfully !!", "")
    this.ResetForm();
    this.Email='';
    this.productPrice=0;
    this.productid=0;
    }
  showUpdatValidation() {
    this.notifyService.showSuccess("Please enter the details..", "")
    this.ResetForm();
  }
  
  getAllCities(): string[] {
    return ['Chennai', 'Mumbai', 'Delhi'];
  }
  getAllStates():string[]{
    return ['TamilNadu','Maharashtra','Uttar Pradesh'];
  }
  ResetForm(){
    this.Myform.reset();
    this.initialiseForm();
    this.submitted=false;
  };

  deleteBid(){
    this.dialogdisplaydelete=true;
if (this.Emaildelete != ''){
    this.notifyService.showSuccess("Deleted Successfully", "")
    this.ResetForm();}

    }
  UpdateBid(){
this.dialogdisplay=true;
  }
  UpdateBidDetails(){
   // var UpdateBidDetails :UpdatBid;
   this.UpdateBidDetails1.Email= this.Email;
   this.UpdateBidDetails1.ProductId= this.productid;
   this.UpdateBidDetails1.BidAmount=  this.productPrice;
    console.log('updateinput',this.UpdateBidDetails1);
    if (this.UpdateBidDetails1.Email != "")
    {
this.buyerService.UpdateBidDetails(this.UpdateBidDetails1).subscribe(
  data =>{
    this.showUpdateSuccess();
    console.log('updatebid',data);}
  
);}
else{
  this.showUpdatValidation();
}

}}

