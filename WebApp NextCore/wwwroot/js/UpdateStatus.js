function updateStatus(id, status) {
    fetch('/Admin/UpdateStatus', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
        },
        body: JSON.stringify({
            id: id,
            status: status
        })
    })
        .then(response => {
            if (response.ok) {

                // 🔥 обновляем текст статуса
                const statusElement = document.getElementById("status-" + id);
                statusElement.innerText = status;

                // 🔥 обновляем цвет
                statusElement.className = "status " + status.toLowerCase().replace(" ", "");

            } else {
                alert("Ошибка при обновлении");
            }
        });
}
