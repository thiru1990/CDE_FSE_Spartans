import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuctionNavbarComponent } from './NavBar/auction-navbar/auction-navbar.component';
import { AuctionFooterComponent } from './footer/auction-footer/auction-footer.component';
import { BuyerComponent } from './buyer/buyer.component';
import { SellerComponent } from './seller/seller.component';
import { BidDetailsComponent } from './bid-details/bid-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
  

@NgModule({
  declarations: [
    AppComponent,
    AuctionNavbarComponent,
    AuctionFooterComponent,
    BuyerComponent,
    SellerComponent,
    BidDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
