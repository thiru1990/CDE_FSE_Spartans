import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators,FormBuilder, AbstractControl} from '@angular/forms';
import { SellerService } from '../Shared/Service/Seller/seller.service';
import { NotificationService } from '../Shared/Service/notification.service'

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.css']
})
export class SellerComponent implements OnInit {
  Myform : FormGroup;
  submitted = false;
  Categories: string[];
  cities: string[];
  states: string[];
  dialogdisplaydelete:boolean=false;
  productiddelete:string='';
  productid:any;
  productPrice:any;
  constructor(private formBuilder:FormBuilder,private sellerService:SellerService,
    private notifyService : NotificationService) { }

  ngOnInit(): void {
    this.initialiseForm();
    this.Categories = this.getAllCategory();
    this.cities=this.getAllCities();
    this.states=this.getAllStates();
  }
  initialiseForm(){
  this.Myform=this.formBuilder.group({
    ProductName: new FormControl('', Validators.required),
    ShortDescription: new FormControl('', Validators.required),
    DetailedDescription:new FormControl ('',Validators.required),
    Category:new FormControl ('',Validators.required),
    StartingPrice: new FormControl('', Validators.required),
    BidEndDate: new FormControl('', Validators.required),
    //Add information
    FirstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    LastName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    Address: new FormControl('', Validators.required),
    City:new FormControl ('',Validators.required),
    State:new FormControl ('',Validators.required),
    Pin: new FormControl('', Validators.required),
    Phone: new FormControl('', [Validators.required,Validators.maxLength(12)]),
    Email: new FormControl('', [Validators.required,Validators.email]),
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
     console.log("Token",localStorage.getItem('access_token')); 
this.sellerService.addProduct({
  ProductName:this.Myform.get('ProductName')?.value,
  ShortDescription:this.Myform.get('ShortDescription')?.value,
  DetailedDescription:this.Myform.get('DetailedDescription')?.value,
  Category:this.Myform.get('Category')?.value,
  StartingPrice:this.Myform.get('StartingPrice')?.value,
  BidEndDate:this.Myform.get('BidEndDate')?.value,
  //Add info
  FirstName:this.Myform.get('FirstName')?.value,
  LastName:this.Myform.get('LastName')?.value,
  Address:this.Myform.get('Address')?.value,
  City:this.Myform.get('City')?.value,
  State:this.Myform.get('State')?.value,
  Pin:this.Myform.get('Pin')?.value,
  Phone:this.Myform.get('Phone')?.value,
  Email:this.Myform.get('Email')?.value,
},localStorage.getItem('access_token')
).subscribe(
  data => {console.log('result',data);
this.showSuccess();
}); } 
else
this.notifyService.showError("Please Enter the valid input to AddProduct", "")
}
  showSuccess() {
    this.notifyService.showSuccess("Product Added successfully !!", "");
    this.ResetForm();
  }
  getAllCategory(): string[] {
    return ['Painting', 'Scultpor', 'Ornament'];
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
  }
  DeleteProduct(){
    this.dialogdisplaydelete=true;
  }
  deleteProductID(){
    if (this.productiddelete != ''){
    this.sellerService.deleteProductId(this.productiddelete,localStorage.getItem('access_token')).subscribe(
      data=>{
        this.notifyService.showSuccess("Deleted Successfully", "")
        console.log('deleteresulr',data)
      }
    );}
    else
    this.notifyService.showError("Please Enter the productId to delete", "")
  }
 }
