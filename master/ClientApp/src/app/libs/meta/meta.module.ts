import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { TreeLookupComponent } from './components/tree-lookup/tree-lookup.component';
import { ImageLookupComponent } from './components/image-lookup/image-lookup.component';
import { HttpClientModule } from '@angular/common/http';


const COMPONENTS=[TreeLookupComponent,ImageLookupComponent]

@NgModule({
  imports: [SharedModule.forRoot(), HttpClientModule],
    exports:[SharedModule,COMPONENTS],
    declarations:[COMPONENTS]
})
export class MetaModule{

}
