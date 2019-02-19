import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ShareModule } from '../share/share.module';
import { RouterModule } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ProductDetailPageComponent } from './pages/product-detail-page/product-detail-page.component';

@NgModule({
    declarations: [HomePageComponent, ProductDetailPageComponent],
    imports: [ShareModule, RouterModule.forChild([
        { path: "", component: HomePageComponent },
        { path: "product-detail", component: ProductDetailPageComponent }
    ])],
    entryComponents: [HomePageComponent, ProductDetailPageComponent],
    exports: [HomePageComponent, ProductDetailPageComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HomeModule {

}