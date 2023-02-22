import { ListService } from '@abp/ng.core';
import { InvitedUserAppServicesService } from './../proxy/invited-users/invited-user-app-services.service';
import { Component, OnInit } from '@angular/core';
import { query } from '@angular/animations';

@Component({
  selector: 'app-invited-authors',
  templateUrl: './invited-authors.component.html',
  styleUrls: ['./invited-authors.component.scss']
})
export class InvitedAuthorsComponent implements OnInit {
  isModalOpen = false
  invitedUsers = null

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    const userStreamCreator = (query) => this.appService.getList(query)
    this.get(userStreamCreator)

  }

  constructor(public readonly list: ListService, private appService:InvitedUserAppServicesService){}

  get(userStreamCreator)
  {
    this.list.hookToQuery(userStreamCreator).subscribe(res => {
      console.log(res);
    })
  }
}
