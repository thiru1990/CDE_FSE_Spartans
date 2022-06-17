import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators,FormBuilder, AbstractControl} from '@angular/forms';
import { BuyerService } from '../Shared/Service/Buyer/buyer.service';
@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.css']
})
export class SellerComponent implements OnInit {
  Myform : FormGroup;
  submitted = false;
  cities: string[];
  states: string[];
  dialogdisplay:boolean=false;
  productid:any;
  productPrice:any;
  constructor(private formBuilder:FormBuilder,private buyerService:BuyerService) { }

  ngOnInit(): void {
    this.initialiseForm();
    this.cities = this.getAllCities();
    this.states=this.getAllStates();
  }
  initialiseForm(){
  this.Myform=this.formBuilder.group({
    Firstname: new FormControl('', [Validators.required, Validators.minLength(3)]),
    Lastname: new FormControl('', [Validators.required, Validators.minLength(3)]),
    Address: new FormControl('', Validators.required),
    city:new FormControl ('',Validators.required),
    state:new FormControl ('',Validators.required),
    pincode: new FormControl('', Validators.required),
    PhoneNo: new FormControl('', [Validators.required,Validators.maxLength(12)]),
    email: new FormControl('', [Validators.required,Validators.email]),
    productid:new FormControl('',[Validators.required,Validators.required]),
    amount:new FormControl('',[Validators.required,Validators.required])
  });}
  
  get f(): { [key: string]: AbstractControl } {
    return this.Myform.controls;
  }
   
  submit(): void {
    this.submitted = true;

    if (this.Myform.invalid) {
      console.log('Failedvalidation',"failedvalidation");
    }
this.buyerService.placeBidDetails({
  Firstname:this.Myform.get('Firstname')?.value,
  Lastname:this.Myform.get('Lastname')?.value,
  Address:this.Myform.get('Address')?.value,
  city:this.Myform.get('city')?.value,
  state:this.Myform.get('state')?.value,
  pincode:this.Myform.get('pincode')?.value,
  PhoneNo:this.Myform.get('PhoneNo')?.value,
  email:this.Myform.get('email')?.value,
  productid:this.Myform.get('productid')?.value,
  amount:this.Myform.get('amount')?.value
});

    console.log(JSON.stringify(this.Myform.value, null, 2));
  }
  getAllCities(): string[] {
    return ['Painting', 'Scultpor', 'Ornament'];
  }
  getAllStates():string[]{
    return ['TamilNadu','Maharashtra','Uttar Pradesh'];
  }
  ResetForm(){
    this.Myform.reset();
    this.initialiseForm();
  };
  UpdateBid(){
this.dialogdisplay=true;
  }
  UpdateBidDetails(){
    var UpdateBidDetails :any[] ;
    UpdateBidDetails=  [this.productid,  this.productPrice];
    
//this.buyerService.UpdateBidDetails(UpdateBidDetails)();
  
}}
