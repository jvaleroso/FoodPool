import { Component, OnInit, Input } from '@angular/core';
import { Treatment } from '../../models/treatment';


@Component({
	selector: 'ca-treatment',
	templateUrl: 'treatment.component.html',
	styleUrls: ['./treatment.component.css']
})

export class TreatmentComponent implements OnInit {
	@Input() treatments: Treatment[]; 
	@Input() selectedTreatment: Treatment;

	constructor() { }

	onSelect(treatment: Treatment):void {
		this.selectedTreatment = treatment;
	}

    ngOnInit(): void {
        if(this.treatments && this.treatments.length > 0){
            this.selectedTreatment = this.treatments[0];
        }
    }
	
}