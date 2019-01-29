import { WorkHistoryDetail } from './WorkHistoryDetail';

export class WorkHistory {
    WorkHistoryId: string;
    CareerInfoId: string;
    Sequence: number;
    Employer: string;
    JobTitle: string;
    JobDescription: string;
    StartDate: Date;
    EndDate: Date;
    Enabled: boolean;
    WorkHistoryDetails: WorkHistoryDetail[];
}
