import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TreatmentComponent } from './components/treatment/treatment.component';
import { StatutoryComponent } from './components/statutory/statutory.component';
import { StallComponent } from './components/stall/stall.component';



const routes: Routes = [
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'stalls', component: StallComponent },
            { path: '**', redirectTo: 'home' }
        ];

@NgModule({	
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})


export class AppRoutingModule {

}