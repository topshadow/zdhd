import { Component, ViewChild, Injector } from '@angular/core';
import { Banner } from '../struct/banner';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../../environments/environment';
import { ODataResponse } from 'src/app/libs/share/struct/odata-response';
import { ProductTag } from '../struct/product-tag';
import { OnsCarouselElement } from 'onsenui';
import { OnsNavigator } from 'ngx-onsenui';
import { ProductDetailPageComponent } from '../product-detail-page/product-detail-page.component';

@Component({
    selector: "ons-page[home]",
    templateUrl: "./home-page.component.html"
})
export class HomePageComponent {
    @ViewChild('carousel') carousel: { nativeElement: OnsCarouselElement };
    bannerUrl = environment.ip + "/api/Product/Banner";
    /** 最新产品 */
    productTagUrl = environment.ip + "/api/App/Home/productTag";
    banners: Banner[] = []
    newProductTagId = 1;
    activeMapIndexId: number[] = [1, 2, 3, 4, 5, 0];

    selectedProductTag: ProductTag;
    activeIndex: number = 0;

    constructor(public httpClient: HttpClient,
        private _navigator: OnsNavigator,
        private inj: Injector
    ) { }
    async ngOnInit() {
        let data: ODataResponse<Banner> = await this.httpClient.get(this.bannerUrl).toPromise() as any;
        this.banners = data.data;
        debugger;
        let groups: ODataResponse<ProductTag> = await this.httpClient.get(this.productTagUrl, { params: { filter: JSON.stringify(["productTagId", "=", 1 as any]) } }).toPromise() as any;
        this.selectedProductTag = groups.data[0];

    }

    async postchange($event) {
        this.activeIndex = $event.activeIndex;
        let groups: ODataResponse<ProductTag> = await this.httpClient.get(this.productTagUrl, {
            params: {
                filter: JSON.stringify(["productTagId", "=", this.activeMapIndexId[this.activeIndex] as any])
            }
        }).toPromise() as any;
        this.selectedProductTag = groups.data[0];
    }

    public go(index: number) {
        this.activeIndex = index;
        debugger
        this.carousel.nativeElement.setActiveIndex(index);

    }


    goProductDetailPage() {
        this._navigator.element.pushPage(ProductDetailPageComponent);
    }


}
