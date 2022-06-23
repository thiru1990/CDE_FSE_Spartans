import { Component, OnInit } from '@angular/core';
import { SellerService } from '../Shared/Service/Seller/seller.service'; 
import { map } from 'rxjs/operators'
import { Products } from '../Model/Products';
import { BidDetails } from '../Model/BidDetails';
import { BidsReceived } from '../Model/BidDetails';
import { FormGroup, FormControl, Validators,FormBuilder, AbstractControl} from '@angular/forms';
import { NotificationService } from '../Shared/Service/notification.service'

@Component({
  selector: 'app-bid-details',
  templateUrl: './bid-details.component.html',
  styleUrls: ['./bid-details.component.css']
})
export class BidDetailsComponent implements OnInit {
  Myform : FormGroup;
  submitted = false;
  productid:string='1';
  products: Products[];  
  shortDescription: string
  DetailedDescription :string
  Category:string //should be enum
  StartingPrice :number
  BidEndDate :Date
  //BidsReceived: BidsReceived[]
  BidDetails:BidDetails
  constructor(private formBuilder:FormBuilder,private sellerService:SellerService) { }

  ngOnInit(): void {
    this.initialiseForm();
   this.GetProducts();
   //this.products= [{productName:"product2", productId:1}, {productName:"product1", productId:1}];    
  }
  initialiseForm(){
    this.Myform=this.formBuilder.group({   
      product:new FormControl ('',Validators.required)
    });}

  GetBidDetails(){ 
    this.productid =this.Myform.get('product')?.value;
    this.sellerService.GetBidDetails(this.productid,localStorage.getItem('access_token'))
   // .pipe(map(response => {this.ShortDescription= response.ShortDescription}))
    .subscribe(
      data=>{
        console.log('GetBidDetails',data)   
        this.BidDetails = data 
        console.log('this.BidDetails',this.BidDetails.bidsReceived)   
      }
     );
   // this.ShortDescription =this.BidDetails.ShortDescription;
   // this.DetailedDescription=this.BidDetails.DetailedDescription;
   // this.Category=this.BidDetails.Category;
   // this.StartingPrice=this.BidDetails.StartingPrice;
   // this.BidEndDate = this.BidDetails.BidEndDate;
   // this.BidsReceived = this.BidDetails.BidsReceived;
  }
  submit(): void {
    this.submitted = true;
  }
  GetProducts(){
  return this.sellerService.GetProducts(localStorage.getItem('access_token'))
  // .pipe(map(response => {return response.productName}))
   .subscribe(
      data=>{
     console.log('GetProducts',data)    
     this.products= data  
       console.log('products',this.products)          
      }      
     )
      }

}

