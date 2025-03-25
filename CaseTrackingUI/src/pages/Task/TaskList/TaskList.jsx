import React, { useState, useEffect } from "react";
import "./task-list.scss";
import TaskCard from "../../../components/TaskCard/TaskCard";
import agent from "../../../api/agents";
import CreateTask from "../CreateTask/CreateTask";
import moment from "moment";

const TaskList = () => {
  const [Dcase, setDCase] = useState([]);
  const [taskat, setTaskat] = useState([]);
  const [isOpen, setIsOpen] = useState(false);
  const [filters, setFilters] = useState({
    status: "all",
    dueDate: "",
    caseId: "",
  });

  const handleOpen = () => {
    setIsOpen((prev) => !prev);
  };

  const handleFilterChange = (e) => {
    e.preventDefault();
    setFilters({
      ...filters,
      [e.target.name]: e.target.value,
    });
  };

  const updateTaskInList = (updatedTask) => {
    setTaskat((prev) =>
      prev.map((t) => (t.id === updatedTask.id ? updatedTask : t))
    );
  };

  useEffect(() => {
    agent.Cases.get().then((response) => {
      setDCase(response);
    });
  }, []);

  useEffect(() => {
    agent.Tasks.get().then((response) => {
      setTaskat(response);
    });
  }, []);

  let filteredTasks = taskat;

  if (filters.status !== "all") {
    filteredTasks = filteredTasks.filter(
      (task) => String(task.status) === filters.status
    );
  }

  if (filters.dueDate !== "") {
    filteredTasks = filteredTasks.filter(
      (task) => moment(task.dueDate).format("YYYY-MM-DD") === filters.dueDate
    );
  }

  if (filters.caseId !== "") {
    filteredTasks = filteredTasks.filter(
      (task) => String(task.caseId) === filters.caseId
    );
  }

  return (
    <>
      <h1>Tasks</h1>
      <button className="add_task" onClick={handleOpen}>
        + Add task
      </button>
      <div className="filters">
        <div className="filter-item">
          <label htmlFor="status-filter">Filter by status:</label>
          <select
            id="status-filter"
            name="status"
            value={filters.status}
            onChange={handleFilterChange}
          >
            <option value="all">All</option>
            <option value="true">Done</option>
            <option value="false">Not Done</option>
          </select>
        </div>

        <div className="filter-item">
          <label htmlFor="due-date-filter">Filter by due date:</label>
          <input
            type="date"
            id="due-date-filter"
            value={filters.dueDate}
            onChange={(e) =>
              setFilters({ ...filters, dueDate: e.target.value })
            }
          />
        </div>

        <div className="filter-item">
          <label htmlFor="case-filter">Filter by case:</label>
          <select
            id="case-filter"
            name="caseId"
            value={filters.caseId}
            onChange={handleFilterChange}
          >
            <option value="">All</option>
            <option value="0">No case</option>
            {Dcase.map((caseItem) => (
              <option key={caseItem.id} value={caseItem.id}>
                {caseItem.title}
              </option>
            ))}
          </select>
        </div>
      </div>
      <div className="card-layout column">
        {React.Children.toArray(
          filteredTasks.map((taskat) => (
            <TaskCard
              taskID={taskat.id}
              CaseId={taskat.caseId}
              title={taskat.title}
              details={taskat.details}
              dateCreated={taskat.dateCreated}
              dueDate={taskat.dueDate}
              status={taskat.status}
              updateTask={updateTaskInList}
            />
          ))
        )}
      </div>
      <CreateTask setIsOpen={setIsOpen} isOpen={isOpen} />
    </>
  );
};

export default TaskList;