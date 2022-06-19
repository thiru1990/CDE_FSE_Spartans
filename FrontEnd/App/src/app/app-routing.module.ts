import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BidDetailsComponent } from './bid-details/bid-details.component';
import { BuyerComponent } from './buyer/buyer.component';
import { LoginComponent } from './login/login.component';
import { SellerComponent } from './seller/seller.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  { path: 'Buyer', component: BuyerComponent },
  { path: 'Seller', component: SellerComponent },
  { path: 'BidDetails', component: BidDetailsComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
