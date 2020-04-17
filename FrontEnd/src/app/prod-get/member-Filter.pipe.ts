import { Pipe ,PipeTransform} from '@angular/core';



@Pipe({name:'memberFilter'})
export class MemberFilterPipe implements PipeTransform{
    transform(members: any[], searchTerm: string): any[]{
        if(!members || !searchTerm)
        {
            return members;
        }
        return members.filter(member =>
            member.name.toLowerCase().indexof(searchTerm.toLowerCase()) !== -1);

    }
}