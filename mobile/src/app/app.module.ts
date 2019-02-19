import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeModule } from './libs/home/home.module';
import { HomePageComponent } from './libs/home/pages/home-page/home-page.component';
import { ShareModule } from './libs/share/share.module';
import { ProductDetailPageComponent } from './libs/home/pages/product-detail-page/product-detail-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    ProductDetailPageComponent

  ],
  imports: [
    // HomeModule,
    ShareModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  entryComponents: [HomePageComponent, ProductDetailPageComponent]
})
export class AppModule { }
