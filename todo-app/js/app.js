const input = document.getElementById('task-input');
const addBtn = document.getElementById('add-btn');
const list = document.getElementById('task-list');

// Load saved tasks
function loadTasks() {
  const saved = JSON.parse(localStorage.getItem('tasks')) || [];
  saved.forEach(task => addTask(task.text, task.done));
}

// Save tasks to localStorage
function saveTasks() {
  const tasks = [...list.children].map(li => ({
    text: li.textContent,
    done: li.classList.contains('completed')
  }));
  localStorage.setItem('tasks', JSON.stringify(tasks));
}

// Add a new task
function addTask(text, done = false) {
  const li = document.createElement('li');
  li.textContent = text;

  if (done) li.classList.add('completed');

  // Toggle completed when clicked
  li.addEventListener('click', () => {
    li.classList.toggle('completed');
    saveTasks();
  });

  // Right-click to delete
  li.addEventListener('contextmenu', e => {
    e.preventDefault();
    li.remove();
    saveTasks();
  });

  list.appendChild(li);
  saveTasks();
}

addBtn.addEventListener('click', () => {
  if (input.value.trim() !== '') {
    addTask(input.value.trim());
    input.value = '';
  }
});

loadTasks();
