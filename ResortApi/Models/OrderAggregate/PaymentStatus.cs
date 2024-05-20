namespace ResortApi.Models.OrderAggregate
{
    public enum PaymentStatus
    {
        WorkInProgress, // กำลังดำเนินรายการ
        WaitingForCheck, // กำลังตรวจสอบ
        SuccessfulTransaction,  // การทำรายการสำเร็จ
        CancelTransaction, // ยกเลิก
    }
}
