import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import {ToastyModule}from 'ng2-toasty'

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        ToastyModule.forRoot(),
        ServerModule,
        AppModuleShared
    ]
})
export class AppModule {
}
