package com.example.api;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/entities")
public class EntityController {

    @Autowired
    private EntityRepository entityRepository;

    @GetMapping
    public List<EntityExample> getAllEntities() {
        return entityRepository.findAll();
    }
}
