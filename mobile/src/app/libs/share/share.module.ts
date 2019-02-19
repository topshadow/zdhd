import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { OnsenModule } from 'ngx-onsenui';
const MODULES: any[] = [CommonModule, OnsenModule, HttpClientModule];

@NgModule({
    imports: [...MODULES],
    exports: [...MODULES]
})
export class ShareModule {

}