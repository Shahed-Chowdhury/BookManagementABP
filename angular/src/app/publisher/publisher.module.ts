import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';

import { PublisherRoutingModule } from './publisher-routing.module';
import { PublisherComponent } from './publisher.component';


@NgModule({
  declarations: [
    PublisherComponent
  ],
  imports: [
    SharedModule,
    PublisherRoutingModule
  ]
})
export class PublisherModule { }
