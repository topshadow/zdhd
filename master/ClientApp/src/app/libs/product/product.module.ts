import { Component, NgModule } from '@angular/core';
import { MetaModule } from '../meta/meta.module';
import { RouterModule } from '@angular/router';
import { ProductPageComponent } from './pages/product-page/product-page.component';
import { SharedModule } from '../../../app/shared/shared.module';

@NgModule({ 
  declarations: [ProductPageComponent],
  imports: [SharedModule.forRoot(), MetaModule, RouterModule.forChild([
    { path: "product", component: ProductPageComponent }
  ])]
}) 
export class ProductModule {
}
