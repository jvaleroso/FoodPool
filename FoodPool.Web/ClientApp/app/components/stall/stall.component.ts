import { Component, OnInit } from '@angular/core';
import { Stall } from '../../models/stall';
import { StallService } from '../../services/stall/stall.service';


import { Observable }        from 'rxjs/Observable';
import { Subject }           from 'rxjs/Subject';

// Observable class extensions
import 'rxjs/add/observable/of';
// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'fp-stall',
    templateUrl: 'stall.component.html',
    styleUrls: ['./stall.component.css']
})


export class StallComponent implements OnInit {
    stalls: Observable<Stall[]>;
    newStall: Stall = new Stall();  
    private searchTerms = new Subject<string>();

    constructor(private stallService: StallService){}

    ngOnInit() {
        this.stalls = this.searchTerms
                            .debounceTime(300) // wait 300ms after each keystroke before considering the term
					        .distinctUntilChanged() // ignore if next search term is same as previous
					        .switchMap(term => term ? // ignore if next search term is same as previous
                            this.stallService.search(term): Observable.of<Stall[]>([])) 
					        .catch(error => {
					            console.log(error);
					         return   Observable.of<Stall[]>([]);
					        });
        this.initialize();
    }

    initialize(): void {
            //this.stalls.subscribe(s => {
              //  console.log(s);}
           // );
            this.search('');
        //    this.stallService.getStalls().subscribe(
          //  stalls => this.stalls2 = stalls,
           // error=> console.log(error));
    }

    Add(): void {
        this.stallService.create(this.newStall).subscribe(s => {
            this.newStall = new Stall();
          //  this.stalls2.push(s);
        });
    }

    delete(stall: Stall): void
    {
        this.stallService.delete(stall.id).then(()=> {
            
             this.search('');

			if(this.newStall === stall) { 
			    this.newStall = null; 
			};
        })
    }

    search(term: string): void {
        this.searchTerms.next(term);
    }

}