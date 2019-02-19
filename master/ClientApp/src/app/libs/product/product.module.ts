import { Component, NgModule } from '@angular/core';
import { MetaModule } from '../meta/meta.module';
import { RouterModule } from '@angular/router';
import { ProductPageComponent } from './pages/product-page/product-page.component';
import { SharedModule } from '../../../app/shared/shared.module';
import { ProductTagPageComponent } from './pages/product-tag-page/product-tag-page.component';
import { BannerPageComponent } from './pages/banner-page/banner-page.component';

@NgModule({
  declarations: [ProductPageComponent, ProductTagPageComponent, BannerPageComponent],
  imports: [SharedModule.forRoot(), MetaModule, RouterModule.forChild([
    { path: "product", component: ProductPageComponent },
    { path: "product-tag", component: ProductTagPageComponent },
    { path: "banner", component: BannerPageComponent }

  ])]
}) 
export class ProductModule {
}
