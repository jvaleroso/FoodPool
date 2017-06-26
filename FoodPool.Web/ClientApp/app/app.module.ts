import { NgModule } from '@angular/core';
import { UniversalModule } from 'angular2-universal';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TreatmentComponent } from './components/treatment/treatment.component';
import { TreatmentService } from './services/treatment/treatment.service';
import { StallService } from './services/stall/stall.service';
import { StatutoryComponent } from './components/statutory/statutory.component';
import { StallComponent } from './components/stall/stall.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        TreatmentComponent,
        StatutoryComponent,
        StallComponent,
        HomeComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        AppRoutingModule
    ],
    providers: [ TreatmentService, StallService ]
})
export class AppModule {
}
