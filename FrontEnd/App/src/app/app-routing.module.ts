import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BidDetailsComponent } from './bid-details/bid-details.component';
import { BuyerComponent } from './buyer/buyer.component';
import { SellerComponent } from './seller/seller.component';

const routes: Routes = [
  { path: 'Buyer', component: BuyerComponent },
  { path: 'Seller', component: SellerComponent },
  { path: 'BidDetails', component: BidDetailsComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
