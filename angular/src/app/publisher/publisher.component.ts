import { PublisherDTO } from './../proxy/publishers/models';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { PublisherService } from './../proxy/publishers/publisher.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.scss'],
  providers: [ListService]
})
export class PublisherComponent implements OnInit {

  publishers = {items: [], totalCount: {}} as PagedResultDto<PublisherDTO> 
  isModalOpen = false
  selectedPublishers = {} as PublisherDTO
  form: FormGroup

  constructor(
    private publisherService: PublisherService,
    private fb: FormBuilder,
    public readonly list: ListService,
    private confirmation: ConfirmationService
    ){}

  ngOnInit(): void {
      const publisherStreamCreator = query => this.publisherService.getList(query);
      
      this.list.hookToQuery(publisherStreamCreator).subscribe((response)=>{
        this.publishers = response
      })
  }

  buildForm(){
    this.form = this.fb.group({
      name: [this.selectedPublishers.name || '', Validators.required],
    })
  }

  createPublisher(){
    this.selectedPublishers = {} as PublisherDTO
    this.buildForm()
    this.isModalOpen = true
  }

  editPublisher(publisherId){
    this.publisherService.get(publisherId).subscribe(publisher => {
      this.selectedPublishers = publisher
      this.buildForm()
      this.isModalOpen = true
    })
  }

  deletePublisher(publisherId){
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.publisherService.delete(publisherId).subscribe(() => this.list.get());
      }
    });
  }

  save(){
    if(this.form.invalid){return;}

    const request = this.selectedPublishers.id 

    ? this.publisherService.update(this.selectedPublishers.id , this.form.value)
    : this.publisherService.create(this.form.value)

    request.subscribe(()=>{
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    })

  }
}
